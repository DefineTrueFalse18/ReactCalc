using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IUserRepository : IEntityRepository<User>
    {
        bool Valid(string userName, string password);

        User GetByName(string name);
    }    
}