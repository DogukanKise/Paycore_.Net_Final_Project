using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.Data.Model.Concrete;

namespace Paycore.Data.Mapping.Concrete
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.Generator(Generators.Increment);
            });
            Property(b => b.Name, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("name");
                x.NotNullable(true);
            });
            Table("category");
        }
    }
}
