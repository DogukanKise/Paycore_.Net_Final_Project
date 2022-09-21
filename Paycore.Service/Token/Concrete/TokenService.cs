using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using Paycore.Base.Jwt;
using Paycore.Base.Response;
using Paycore.Base.Token;
using Paycore.Data.Model.Concrete;
using Paycore.Data.Repository.Abstract;
using Paycore.Data.Repository.Concrete;
using Paycore.Service.Token.Abstract;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Paycore.Service.Token.Concrete
{
    public class TokenService : ITokenService
    {
        
        protected readonly ISession session;
        protected readonly IHibernateRepository<User> hibernateRepository;
        private readonly JwtConfig jwtConfig;

        DateTime now = DateTime.UtcNow;

        public TokenService(ISession session,  IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.session = session;
            hibernateRepository = new HibernateRepository<User>(session);
            this.jwtConfig = jwtConfig.CurrentValue;
        }

        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest == null)
                {
                    var response = new BaseResponse<TokenResponse>("Please check information you entered.");
                    return response;

                }
                var user = hibernateRepository.Where(x => x.Email.Equals(tokenRequest.UserName)).FirstOrDefault();

                if (user == null)
                {
                    var response = new BaseResponse<TokenResponse>("Please check information you entered.");
                    return response;
                }
                if (!user.Password.Equals(tokenRequest.Password))
                {
                    var response = new BaseResponse<TokenResponse>("Please check information you entered.");
                    return response;
                }

                string token = GetToken(user, now);

                try
                {
                    user.LastActivity = now;
                    hibernateRepository.BeginTransaction();
                    hibernateRepository.Update(user);
                    hibernateRepository.Commit();
                    hibernateRepository.CloseTransaction();

                    //When the everything is okey
                }
                catch (Exception ex)
                {
                    
                    hibernateRepository.Rollback();
                    hibernateRepository.CloseTransaction();
                    //When the some errors shows up.

                }
                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    UserName = user.Email
                };
                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("", ex);
                return new BaseResponse<TokenResponse>("Generate Token");
            }
        }

        private string GetToken(User user, DateTime time)
        {
            Claim[] claims = GetClaims(user);

            Byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: time.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }


        private Claim[] GetClaims(User user)
        {
            var claims = new[]
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("E-mail", user.Email),
                new Claim("Name", user.Name),
                new Claim("Surname",user.Surname)
            };

            return claims;
        }
    }
}
