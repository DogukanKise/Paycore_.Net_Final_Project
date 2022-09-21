using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.Data.Model.Concrete;

namespace Paycore.Data.Mapping.Concrete
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.Generator(Generators.Increment);
            });
            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("name");
                x.NotNullable(true);
            });
            Property(b => b.Surname, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("surname");
                x.NotNullable(true);
            });
            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("email");
                x.NotNullable(true);
            });
            Property(b => b.Password, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("password");
                x.NotNullable(true);
            });
            Property(b => b.LastActivity, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("lastactivity");
                x.NotNullable(true);
            });
            Table("user");
        }
    }
}
