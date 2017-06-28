using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public abstract class Operation : IDisplayOperation
    {
        public abstract string Name { get; }

        public abstract long Code { get; }

        public abstract double Execute(double[] args);

        public virtual string DisplayName { get { return ""; } } //виртаул,чтобы не обязон было переопредлять это св-во каждому наследнику

        public virtual string Description { get { return ""; } }

        public virtual string Author { get { return "#define TRUE FALSE company inc."; } }

        public virtual string Difficulty { get { return ""; } }
    }
}
