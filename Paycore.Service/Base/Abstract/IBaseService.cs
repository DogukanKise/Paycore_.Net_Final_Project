using Paycore.Base.Response;
using System.Collections.Generic;

namespace Paycore.Service.Base.Abstract
{
    public interface IBaseService<Dto, Entity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        BaseResponse<Dto> Insert(Dto insert);
        BaseResponse<Dto> Update(int id, Dto update);
        BaseResponse<Dto> Remove(int id);
    }
}
