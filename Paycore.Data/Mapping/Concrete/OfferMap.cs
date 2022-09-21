using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.Data.Model.Concrete;

namespace Paycore.Data.Mapping.Concrete
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.Generator(Generators.Increment);
            });
            Property(x => x.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("productid");
                x.NotNullable(true);
            });
            Property(x => x.UserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("userid");
                x.NotNullable(true);
            });
            Property(x => x.Bid, x =>
            {
                x.Type(NHibernateUtil.Double);
                x.Column("bid");
                x.NotNullable(true);
            });
            Property(x => x.Status, x =>
            {
                x.Type(NHibernateUtil.Int16);
                x.Column("status");
                x.NotNullable(true);
            });
            Table("offer");
        }
    }
}
