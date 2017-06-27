using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class DivOperation : Operation
    {
        public override string Name
        {
            get { return "Div"; }
        }

        public override long Code
        {
            get { return 4; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i <= args.Length - 1; i++)
            {
                res /= args[i];
            }
            return res;
        }
    }
}
