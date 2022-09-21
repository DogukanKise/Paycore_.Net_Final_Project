using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paycore.Base.Response;
using Paycore.Dto.Concrete;
using Paycore.Service;
using System.Collections.Generic;

namespace Paycore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("AddProduct")]
        public virtual BaseResponse<ProductDto> AddProduct([FromBody] ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                dto.IsSold = false;
                dto.IsOfferable = true;
                var result = productService.Insert(dto);
                return result;
            }
            return new BaseResponse<ProductDto>(false);
        }
        [HttpGet("GetAll")]
        public virtual BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            var result = productService.GetAll();

            if (!result.Success)
            {
                return new BaseResponse<IEnumerable<ProductDto>>(false);
            }

            if (result.Response is null)
            {
                return new BaseResponse<IEnumerable<ProductDto>>("Result is null.");

            }
            return result;
        }


    }
}
