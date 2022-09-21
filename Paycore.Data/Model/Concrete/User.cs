using Paycore.Data.Model.Abstract;
using System;
using System.Collections.Generic;

namespace Paycore.Data.Model.Concrete
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}
