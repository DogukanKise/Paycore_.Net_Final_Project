using Paycore.Data.Model.Abstract;

namespace Paycore.Data.Model.Concrete
{
    public class Offer : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int UserId { get; set; }
        public virtual double Bid { get; set; } 
        public virtual short Status { get; set; }

    }
}
