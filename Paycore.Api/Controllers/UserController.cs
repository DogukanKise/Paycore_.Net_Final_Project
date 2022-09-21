using Microsoft.AspNetCore.Mvc;
using Paycore.Base.Response;
using Paycore.Dto.Concrete;
using Paycore.Service;

namespace Paycore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("SignUp")]
        public virtual BaseResponse<UserDto> SignUp([FromBody] UserDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = userService.Insert(dto);
                return result;
            }
            return new BaseResponse<UserDto>(false);
        }
    }
}
