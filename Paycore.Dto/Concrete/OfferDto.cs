using Paycore.Dto.Abstract;
using System.Text.Json.Serialization;

namespace Paycore.Dto.Concrete
{
    public class OfferDto : IDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual int UserId { get; set; }
        public virtual double Bid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual short Status { get; set; }
    }
}
