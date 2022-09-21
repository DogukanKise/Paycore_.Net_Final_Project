using AutoMapper;
using NHibernate;
using Paycore.Base.Response;
using Paycore.Base.Util;
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
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<User> hibernateRepository;

        public UserService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<User>(session);
        }
        public override BaseResponse<UserDto> Insert(UserDto insert)
        {
            try
            {
                string tempPassword = insert.Password;
                var tempEntity = mapper.Map<UserDto, User>(insert);
                tempEntity.Password = Util.HashToMD5(tempEntity.Password);
                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                tempEntity.Password = tempPassword;
                return new BaseResponse<UserDto>(mapper.Map<User, UserDto>(tempEntity));

            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<UserDto>(ex.Message);

            }

        }
    }
}
