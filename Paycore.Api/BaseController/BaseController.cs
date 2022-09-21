using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Paycore.Base.Util;
using Paycore.Service.Base.Abstract;

namespace Paycore.Api.BaseController
{
    [Authorize]
    [ApiController]
    public class BaseController<Dto,Entity> : ControllerBase
    {
        private readonly IBaseService<Dto, Entity> baseService;
        int id;
        void GetIdFromRequest()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            id = Util.GetIdFromToken(token);
        }
        public BaseController(IBaseService<Dto, Entity> baseService)
        {
            this.baseService = baseService;
          
        }

        [HttpGet("GetAll")]
        public virtual IActionResult GetAll()
        {
            GetIdFromRequest();
            var result = baseService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] Dto dto)
        {
            if (ModelState.IsValid)
            {
                var result = baseService.Insert(dto);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                if (result.Response is null)
                {
                    return NoContent();
                }

                if (result.Success)
                {
                    return StatusCode(201, result);
                }

                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public virtual IActionResult Update(int id, [FromBody] Dto dto)
        {
            var result = baseService.Update(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(200, result);
            }

            return BadRequest(result);
        }
    }
}
