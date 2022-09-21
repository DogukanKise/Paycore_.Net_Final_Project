using Microsoft.AspNetCore.Mvc;
using Paycore.Base.Response;
using Paycore.Base.Token;
using Paycore.Base.Util;
using Paycore.Service.Token.Abstract;

namespace Paycore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;
        

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("GetToken")]
        public BaseResponse<TokenResponse> GetToken([FromBody] TokenRequest request)
        {
            request.Password= Util.HashToMD5(request.Password);
            var response = tokenService.GenerateToken(request);
            return response;
        }
    }
}
