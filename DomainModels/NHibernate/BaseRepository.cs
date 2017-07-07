using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using NHibernate;
using NHibernate.Criterion;

namespace DomainModels.NHibernate
{
    public class BaseRepository<T> : IEntityRepository<T> where T : class
    {
        public virtual T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual void Delete(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public virtual T Get(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<T>()
                    .List();
            }
        }
        public virtual void Update(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
    }
}
