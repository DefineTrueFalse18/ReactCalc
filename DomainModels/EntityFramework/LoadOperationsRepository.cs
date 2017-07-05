using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using ReactCalc;
using System.Data.Entity;

namespace DomainModels.EntityFramework
{
    public class LoadOperationsRepository : ILoadOperationsRepository
    {
        private IOperationRepository OperRep = new OperationRepository();
        private Calc Calc = new Calc();

        public LoadOperationContext db { get; set; }

        public LoadOperationsRepository()
        {
            this.db = new LoadOperationContext();
        }

        public Operation Create(Operation operation)
        {
            var opersTable = OperRep.GetAll().ToList();
            var opersCalc = Calc.Operations.ToList();

            for (int i = 0; i < opersCalc.Count; i++)
            {
                for (int j = 0; j < opersTable.Count; j++)
                {
                    if (opersCalc[i].Name == opersTable[j].Name)
                    {
                        //operation = OperRep.Get(opersTable[j].Id);
                        //operation.Name = opersCalc[i].Name;
                        //operation.FullName = opersCalc[i].Name;

                        //хак
                        operation = new Operation();
                        operation.Id = opersTable[j].Id;
                        operation.Uid = opersTable[j].Uid;
                        operation.Name = opersCalc[i].Name;
                        operation.FullName = opersCalc[i].Name;

                        Update(operation);
                    }
                }
                operation = new Operation();
                operation.Uid = Guid.NewGuid();
                operation.Name = opersCalc[i].Name;
                operation.FullName = opersCalc[i].Name;

                db.Operation.Add(operation);
                db.SaveChanges();
            }

            return null;
        }

        public void Delete(Operation user)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Operation operation)
        {
            db.Entry(operation).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
