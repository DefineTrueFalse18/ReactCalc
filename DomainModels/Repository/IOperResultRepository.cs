using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IOperResultRepository
    {
        OperationResult Create();

        OperationResult Get(long id);

        void Update(OperationResult operResult);

        void Delete(OperationResult operResult);

        IEnumerable<OperationResult> GetAll();
    }
}
