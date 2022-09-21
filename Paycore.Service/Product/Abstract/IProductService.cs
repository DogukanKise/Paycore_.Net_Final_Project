using Paycore.Base.Response;
using Paycore.Data.Model.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service.Base.Abstract;
using System.Collections.Generic;

namespace Paycore.Service
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        public BaseResponse<IEnumerable<ProductDto>> GetOfferableProducts();
    }
}
