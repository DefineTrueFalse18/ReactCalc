using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class SumOperation : Operation
    {
        public override string Name
        {
            get { return "Sum"; }
        }

        public override long Code
        {
            get { return 1; }
        }

        public override double Execute(double[] args)
        {
            return args.Sum();
        }

        public override string DisplayName
        {
            get { return "Сумма"; }
        }

        public override string Description
        {
            get { return "Су́мма (лат. summa — итог, общее количество) в математике это результат операции сложение числовых величин, либо результат последовательного выполнения нескольких операций сложения (суммирования)"; }
        }

        public override string Difficulty
        {
            get { return "Not"; }
        }
    }
}
