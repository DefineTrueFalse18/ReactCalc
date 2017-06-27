using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public interface IOperation
    {
        string Name { get; }

        long Code { get; }

        double Execute(double[] args);
    }
}
