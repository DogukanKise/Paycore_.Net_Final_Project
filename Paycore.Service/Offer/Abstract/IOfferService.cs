using Paycore.Base.Response;
using Paycore.Data.Model.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service.Base.Abstract;
using System.Collections.Generic;

namespace Paycore.Service
{
    public interface IOfferService :  IBaseService<OfferDto, Offer>
    {
        public BaseResponse<IEnumerable<OfferDto>> GetOfferedProducts(int ownerId);
        public BaseResponse<IEnumerable<OfferDto>> GetBidsByUser(int userId);

    }
}
