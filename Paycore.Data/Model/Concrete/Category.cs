using Paycore.Data.Model.Abstract;
using System.Collections.Generic;

namespace Paycore.Data.Model.Concrete
{
    public class Category : IEntity
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
