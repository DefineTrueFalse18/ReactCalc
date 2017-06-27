using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class MultiplyOperation : Operation
    {
        public override string Name
        {
            get { return "Multiply"; }
        }

        public override long Code
        {
            get { return 3; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i <= args.Length - 1; i++)
            {
                res *= args[i];
            }
            return res;
        }
    }
}
