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
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public override Operation Create()
        {
            return new Operation
            {
                Uid = new Guid()
            };
        }

        public Operation GetByName(string oper)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Operation>().And(or => or.Name == oper).SingleOrDefault();
            }
        }
    }
}
