using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.Data.Model.Concrete;

namespace Paycore.Data.Mapping.Concrete
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.Generator(Generators.Increment);
            });
            Property(b => b.Name, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.Column("name");
                x.NotNullable(true);
            });
            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.Column("description");
                x.NotNullable(true);
            });
            Property(b => b.Color, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("color");
                x.NotNullable(true);
            });
            Property(b => b.Brand, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("brand");
                x.NotNullable(true);
            });
            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Double);
                x.Column("price");
                x.NotNullable(true);
            });
            Property(b => b.IsOfferable, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.Column("isofferable");
                x.NotNullable(true);
            });
            Property(b => b.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.Column("issold");
                x.NotNullable(true);
            });
            Property(x => x.CategoryId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("categoryid");
                x.NotNullable(true);
            });
            Property(x => x.OwnerId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("userid");
                x.NotNullable(true);
            });
            Table("product");
        }
    }
}
