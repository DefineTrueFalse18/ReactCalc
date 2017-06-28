using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class DiffOperation : Operation
    {
        public override string Name
        {
            get { return "Diff"; }
        }

        public override long Code
        {
            get { return 2; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i <= args.Length - 1; i++)
            {
                res -= args[i];
            }
            return res;
        }

        public override string DisplayName
        {
            get { return "Разность"; }
        }

        public override string Description
        {
            get { return "Разность (убавление) — одна из вспомогательных бинарных математических операций (арифметических действий) двух аргументов (уменьшаемого и вычитаемого), результатом которой является новое число (разность), получаемое уменьшением значения первого аргумента на значение второго аргумента."; }
        }

        public override string Difficulty
        {
            get { return "Not"; }
        }
    }
}
