using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncStandartLibrary
{
    public class PowOperation : Operation
    {
        public override long Code
        {
            get { return 6; }
        }

        public override string Name
        {
            get { return "Pow"; }
        }

        public override double Execute(double[] args)
        {
            return Math.Pow(args[0],args[1]);
        }

        public override string Author
        {
            get { return "Elma"; }
        }

        public override string Description
        {
            get { return "Возведе́ние в сте́пень — бинарная операция, первоначально определяемая как результат многократного умножения натурального числа на себя."; }
        }
    }
}
