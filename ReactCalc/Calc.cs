using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactorialLibrary;
using ReactCalc.Models;
using System.Reflection;
using System.IO;


namespace ReactCalc
{
    /// <summary>
    /// Калькулятро
    /// </summary>
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());

            var dllName = Directory.GetCurrentDirectory() + "\\FactorialLibrary.dll";

            if(!Directory.Exists(dllName))
            {
                return;
            }
            //загружаем сборку
            var assembly = Assembly.LoadFrom(dllName);
            //получаем все типы/классы из нее
            var types = assembly.GetTypes();
            //перебираем типы
            foreach (var t in types)
            {
                var interfs = t.GetInterfaces();
                //находим тех кто реализует интерфейс ioperation
                if (interfs.Contains(typeof(IOperation)))
                {
                    //создаем экземпляр найденного класса
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        //добавляем его в наш список операций
                        Operations.Add(instance);
                    }
                }
            }

            //Operations.Add(new FactorialOperation());
        }

        public IList<IOperation> Operations { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            //Находим операция по имени
            IOperation oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {
                //Вычисляем результат
                var result = oper.Execute(args);
                //отдаем пользователю
                return result;
            }

            throw new NotSupportedException("Not found this operation");
        }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }

        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }

        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }








        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Целое число</returns>
        public double Sum(double x, double y)
        {
            return Execute("sum", new[] { x, y }); ;
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

        public double Pow(double x, double y)
        {
            return Math.Pow(x,y);
        }
    }
}
