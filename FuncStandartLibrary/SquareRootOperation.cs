using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncStandartLibrary
{
    public class SquareRootOperation : Operation
    {
        public override long Code
        {
            get { return 5; }
        }

        public override string Name
        {
            get { return "Sqrt"; }
        }

        public override double Execute(double[] args)
        {
            return Math.Sqrt(args[0]);
        }
    }
}
