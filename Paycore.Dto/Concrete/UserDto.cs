using Paycore.Dto.Abstract;
using System;
using System.Text.Json.Serialization;

namespace Paycore.Dto.Concrete
{
    public class UserDto : IDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }

   
}
