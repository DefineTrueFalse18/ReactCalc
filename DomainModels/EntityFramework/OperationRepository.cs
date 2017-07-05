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

        public Operation Create()
        {
            return new Operation()
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(Operation oper)
        {
            context.Entry(oper).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public Operation Get(long id)
        {
            return context.Operations.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return context.Operations.ToList();            
        }

        public void Update(Operation oper)
        {
            context.Entry(oper).State = oper.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Operation GetByName(string name)
        {
            return context.Operations.FirstOrDefault(o => o.Name == name);
        }
    }
}
