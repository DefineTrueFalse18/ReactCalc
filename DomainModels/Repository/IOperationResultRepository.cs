using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IOperationResultRepository : IEntityRepository<OperationResult>
    {
        double GetOldResult(long operationId, string inputData);
    }
}
