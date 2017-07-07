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
    public class ORRepository : BaseRepository<OperationResult>, IOperationResultRepository
    {

        public override OperationResult Create()
        {
            return new OperationResult
            {
                Uid = new Guid()
            };
        }

        #region IOperationResultRepository
        public IEnumerable<OperationResult> GetByUser(User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.QueryOver<OperationResult>()
                    .And(or => or.Author == user);

                return criteria.List();
            }
        }

        public double GetOldResult(long operationId, string inputData)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.QueryOver<OperationResult>()
                    .And(it => it.Operation.Id == operationId && it.InputData == inputData)
                    .OrderBy(it => it.ExecutionDate).Asc()
                    .Take(1);

                var result = criteria.SingleOrDefault();

                return result != null ? result.Result : double.NaN;
            }
        }
        #endregion
    }
}
