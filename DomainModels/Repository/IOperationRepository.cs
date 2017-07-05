using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        Operation GetByName(string oper);
    }
}
