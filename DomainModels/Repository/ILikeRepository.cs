using DomainModels.Models;
using System.Collections.Generic;

namespace DomainModels.Repository
{
    public interface ILikeRepository : IEntityRepository<UserFavouriteResult>
    {
        IEnumerable<UserFavouriteResult> GetLikes(long userId);
    }
}
