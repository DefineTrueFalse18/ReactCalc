using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    /// <summary>
    /// Калькулятро
    /// </summary>
    class Calc
    {
        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Целое число</returns>
        public double Sum(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x">Делимое</param>
        /// <param name="y">Делитель</param>
        /// <returns>Частное</returns>
        public double Div(double x, double y)
        {
            return x / y;
        }

        /// <summary>
        /// Квадратный корень
        /// </summary>
        /// <param name="x">число</param>
        /// <returns></returns>
        public double SquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        /// <summary>
        /// Разность
        /// </summary>
        /// <param name="x">Уменьшаемое</param>
        /// <param name="y">Вычитаемое</param>
        /// <returns>Разность</returns>
        public double Diff(double x, double y)
        {
            return x - y;
        }
    }
}
