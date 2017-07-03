using DomainModels.Repository;
using System;
using System.Collections.Generic;
using DomainModels.Models;
using System.Linq;

namespace DomainModels.EntityFramework
{
    public class OperationResultRepository : IOperationResultRepository
    {
        private CalcContext context { get; set; }

        public OperationResultRepository()
        {
            this.context = new CalcContext();
        }

        public OperationResult Create(OperationResult operResult)
        {
            throw new NotImplementedException();
        }

        public void Delete(OperationResult user)
        {
            throw new NotImplementedException();
        }

        public OperationResult Get(long id)
        {
            return context.OperationResult.FirstOrDefault(u => u.AuthorId == id);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OperationResult user)
        {
            throw new NotImplementedException();
        }
    }
}
