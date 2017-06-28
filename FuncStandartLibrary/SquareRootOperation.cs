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

        public override string Author
        {
            get { return "Elma"; }
        }

        public override string Description
        {
            get { return "Квадра́тный ко́рень из. (корень 2-й степени, ) — это решение уравнения: . Иначе говоря, квадратный корень из. — число, дающее. при возведении в квадрат."; }
        }
    }
}
