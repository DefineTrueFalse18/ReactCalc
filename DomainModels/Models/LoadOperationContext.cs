using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class LoadOperationContext :DbContext
    {
        public LoadOperationContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rustam\Desktop\Work(Elewise)\ReactCalc\DomainModels\AppData\reactcalc.mdf;Integrated Security=True")
        { }

        public DbSet<Operation> Operation { get; set; }
    }
}
