using NHibernate;
using Paycore.Data.Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Paycore.Data.Repository.Concrete
{
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class
    {
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
            Log.Information("Hibernate session has been started");
        }

        public IQueryable<Entity> Entities => session.Query<Entity>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
            Log.Information("Transaction has been started");
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
                Log.Information("The Transaction has been closed");
            }
        }

        public void Commit()
        {
            transaction.Commit();
            Log.Information("The Transaction has been commited");
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                session.Delete(entity);
                Log.Information("The Entity has been deleted");
            }
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression)
        {

            return session.Query<Entity>().Where(expression).ToList();
        }

        public List<Entity> GetAll()
        {
            return session.Query<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            var entity = session.Get<Entity>(id);
            return entity;
        }

        public void Rollback()
        {
            transaction.Rollback(); 
        }

        public void Save(Entity entity)
        {
            session.Save(entity);
        }

        public void Update(Entity entity)
        {
            session.Update(entity);
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return session.Query<Entity>().Where(where).AsQueryable();
        }
    }
}
