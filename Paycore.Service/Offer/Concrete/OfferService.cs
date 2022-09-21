using AutoMapper;
using NHibernate;
using Paycore.Base.Response;
using Paycore.Data.Model.Concrete;
using Paycore.Data.Repository.Abstract;
using Paycore.Data.Repository.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycore.Service
{
    public class OfferService : BaseService<OfferDto, Offer>, IOfferService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Offer> hibernateRepository;
        protected readonly IHibernateRepository<Product> productRepository;


        public OfferService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<Offer>(session);
            productRepository= new HibernateRepository<Product>(session);
        }
        public virtual BaseResponse<IEnumerable<OfferDto>> GetOfferedProducts(int ownerId)
        {
            var products = productRepository.Find(x => x.OwnerId == ownerId).ToList();
            List<int> productIds = new List<int>();
            foreach (var product in products)
            {
                productIds.Add(product.Id);
            }
            var tempEntity = hibernateRepository.Find(x => x.Status==0 && productIds.Contains(x.ProductId)).ToList();
            var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(tempEntity);
            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }
        public virtual BaseResponse<IEnumerable<OfferDto>> GetBidsByUser(int userId)
        {
            var tempEntity = hibernateRepository.Find(x =>x.UserId== userId).ToList();
            var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(tempEntity);
            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }
    }
}
