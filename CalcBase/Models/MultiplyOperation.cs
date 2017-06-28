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

        public override string DisplayName
        {
            get { return "Произведение"; }
        }

        public override string Description
        {
            get { return "Умноже́ние — одно из четырёх основных арифметических действий. Результат умножения называется произведением, а умножаемые числа — множителями или сомножителями."; }
        }

        public override string Difficulty
        {
            get { return "Not"; }
        }
    }
}
