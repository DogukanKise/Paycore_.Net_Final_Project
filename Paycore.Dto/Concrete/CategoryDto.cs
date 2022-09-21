using Paycore.Dto.Abstract;
using System.Text.Json.Serialization;

namespace Paycore.Dto.Concrete
{
    public class CategoryDto : IDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
