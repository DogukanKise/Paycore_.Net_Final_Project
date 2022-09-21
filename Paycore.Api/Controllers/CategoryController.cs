using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paycore.Api.BaseController;
using Paycore.Data.Model.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service;


namespace Paycore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryDto,Category>
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
            this.categoryService = categoryService;

        }
        [HttpPut("Update")]
        public override IActionResult Update(int id, [FromBody] CategoryDto dto)
        {
            dto.Id = id;
            var result = categoryService.Update(id, dto);

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
