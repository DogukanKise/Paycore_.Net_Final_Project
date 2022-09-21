using AutoMapper;
using NHibernate;
using Paycore.Base.Response;
using Paycore.Data.Model.Concrete;
using Paycore.Data.Repository.Abstract;
using Paycore.Data.Repository.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service.Base.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Paycore.Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepository;

        public ProductService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<Product>(session);
        }

        public virtual BaseResponse<IEnumerable<ProductDto>> GetOfferableProducts()
        {
            var tempEntity = hibernateRepository.Find(x=>x.IsOfferable).ToList();
            var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(tempEntity);
            return new BaseResponse<IEnumerable<ProductDto>>(result);

        }
    }
}
