using AutoMapper;
using NHibernate;
using Paycore.Data.Model.Concrete;
using Paycore.Data.Repository.Abstract;
using Paycore.Data.Repository.Concrete;
using Paycore.Dto.Concrete;
using Paycore.Service.Base.Concrete;

namespace Paycore.Service
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<Category>(session);
        }
    }
}
