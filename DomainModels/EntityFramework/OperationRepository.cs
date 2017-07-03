using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
    public class OperationRepository : IOperationRepository
    {
        private CalcContext context { get; set; }

        public OperationRepository()
        {
            this.context = new CalcContext();
        }

        public Operation Create(Operation oper)
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation user)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            return context.Operation.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return context.Operation.ToList();
        }

        public void Update(Operation user)
        {
            throw new NotImplementedException();
        }
    }
}
