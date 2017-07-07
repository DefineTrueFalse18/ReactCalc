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

        public OperationResult Create()
        {
            return new OperationResult()
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(OperationResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public OperationResult Get(long id)
        {
            return context.OperationResults.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            return context.OperationResults.ToList();
        }

        public void Update(OperationResult result)
        {
            context.Entry(result).State = result.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public double GetOldResult(long operationId, string inputData)
        {
            var rec = context.OperationResults
                .FirstOrDefault(u => u.Operation.Id == operationId && u.InputData == inputData);
            return rec != null
                ? rec.Result
                : double.NaN;
        }

        public IEnumerable<OperationResult> GetByUser(User user)
        {
            if (user == null)
                return new OperationResult[0];

            return context.OperationResults
                .Where(or => or.Author.Id == user.Id).ToList();
        }
    }
}
