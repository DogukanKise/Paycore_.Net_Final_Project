using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Paycore.Base.Response;
using Paycore.Base.Util;
using Paycore.Dto.Concrete;
using Paycore.Service;
using System.Collections.Generic;

namespace Paycore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;
        private readonly IProductService productService;
        int id;
        void GetIdFromRequest()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            id = Util.GetIdFromToken(token);
        }
        public OfferController(IOfferService offerService, IProductService productService)
        {
            this.offerService = offerService;
            this.productService = productService;
        }

        [HttpGet("GetOfferableProducts")]
        public virtual BaseResponse<IEnumerable<ProductDto>> GetOfferableProducts()
        {
            var result = productService.GetOfferableProducts();
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
        [HttpPost("CreateOffer")]
        public virtual IActionResult CreateOffer([FromBody] OfferDto dto)
        {
            GetIdFromRequest();
            dto.UserId = id;
            if (ModelState.IsValid)
            {
                var result = offerService.Insert(dto);

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
        [HttpPost("Buy")]
        public virtual IActionResult Buy([FromQuery] int productId)
        {
            GetIdFromRequest();
            if (productId > 0)
            {
                // Get Id from authorization values.
                var dto = productService.GetById(productId).Response; // Get selected product by id.
                dto.OwnerId = id;
                dto.IsSold = true;
                dto.IsOfferable = false;
                var result = productService.Update(productId, dto);

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
        [HttpGet("GetOffers")]
        public virtual BaseResponse<IEnumerable<OfferDto>> GetOffers()
        {
            GetIdFromRequest();
            var result = offerService.GetOfferedProducts(id);
            if (!result.Success)
            {
                return new BaseResponse<IEnumerable<OfferDto>>(false);
            }

            if (result.Response is null)
            {
                return new BaseResponse<IEnumerable<OfferDto>>("Result is null.");

            }
            return result;
        }
        [HttpGet("GetBidsByUser")]
        public virtual BaseResponse<IEnumerable<OfferDto>> GetBidsByUser()
        {
            GetIdFromRequest();
            var result = offerService.GetBidsByUser(id);
            if (!result.Success)
            {
                return new BaseResponse<IEnumerable<OfferDto>>(false);
            }

            if (result.Response is null)
            {
                return new BaseResponse<IEnumerable<OfferDto>>("Result is null.");

            }
            return result;
        }
        [HttpPost("AcceptOffer")]
        public virtual IActionResult AcceptOffer([FromQuery] int offerId)
        {
            GetIdFromRequest();
            if (offerId > 0)
            {
                // Get Id from authorization values.

                var dto = offerService.GetById(offerId).Response; // Get selected product by id.
                var product = productService.GetById(dto.ProductId);
                if (product.Response.OwnerId == id)
                {
                    dto.Status = 1;
                    var result = offerService.Update(offerId, dto);
                    product.Response.OwnerId = dto.UserId;
                    productService.Update(product.Response.Id, product.Response);
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
            }
            return BadRequest();
        }
        [HttpPost("RejectOffer")]
        public virtual IActionResult RejectOffer([FromQuery] int offerId)
        {
            GetIdFromRequest();
            if (offerId > 0)
            {
                // Get Id from authorization values.
                var dto = offerService.GetById(offerId).Response; // Get selected product by id.)
                var product = productService.GetById(dto.ProductId);
                if (product.Response.OwnerId == id)
                {
                    dto.Status = -1;
                    var result = offerService.Update(offerId, dto);
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
            }
            return BadRequest();
        }
    }
}
