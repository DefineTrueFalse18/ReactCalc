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
    public class LikeRepository : BaseRepository<UserFavouriteResult>, ILikeRepository
    {        
        public IEnumerable<UserFavouriteResult> GetByUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserFavouriteResult> GetLikes(long userId)
        {
            throw new NotImplementedException();
        }

        public double GetOldResult(long operationId, string inputData)
        {
            throw new NotImplementedException();
        }
    }
}
