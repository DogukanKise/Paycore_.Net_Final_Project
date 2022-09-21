using Paycore.Base.Response;
using Paycore.Base.Token;

namespace Paycore.Service.Token.Abstract
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
