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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public override User Create()
        {
            return new User
            {
                Uid = new Guid()
            };
        }

        public override IEnumerable<User> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => !u.IsDeleted)
                    .List();
            }
        }

        public override void Delete(User entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public User GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Login", name))
                    .Add(Restrictions.Eq("IsDeleted", false));

                return criteria.UniqueResult<User>();
            }
        }

        public bool Valid(string userName, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(User));

                criteria.Add(Restrictions.Eq("Login", userName));
                criteria.Add(Restrictions.Eq("Password", password));
                criteria.Add(Restrictions.Eq("IsDeleted", false));

                var user = criteria.UniqueResult<User>();

                return user != null;
            }
        }
    }
}
