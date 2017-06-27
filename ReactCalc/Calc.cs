using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string NameOperation = "";

        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());
            Operations.Add(new DivOperation());
            Operations.Add(new DiffOperation());
            Operations.Add(new MultiplyOperation());


            for (int i = 0; i < 2; i++)
            {
                var dllName = Directory.GetCurrentDirectory();
                if (i == 0)
                {
                    dllName += "\\FactorialLibrary.dll";
                }
                else
                {
                    dllName += "\\FuncStandartLibrary.dll";
                }

                if (!File.Exists(dllName))
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
            }
        }

        public IList<IOperation> Operations { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            //Находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {
                switch (oper.Name)
                {
                    case "Sum":
                        NameOperation = "Сумма = ";
                        break;

                    case "Diff":
                        NameOperation = "Разность = ";
                        break;

                    case "Multiply":
                        NameOperation = "Произведение = ";
                        break;

                    case "Div":
                        NameOperation = "Частное = ";
                        break;

                    case "Sqrt":
                        NameOperation = "Квадратный корень = ";
                        break;

                    case "Pow":
                        NameOperation = "Возведение в степень = ";
                        break;

                    case "Factorial":
                        NameOperation = "Факториал = ";
                        break;

                    default:
                        break;
                }

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

        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Целое число</returns>
        public double Sum(double x, double y)
        {
            return Execute("Sum", new[] { x, y });
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x">Делимое</param>
        /// <param name="y">Делитель</param>
        /// <returns>Частное</returns>
        public double Div(double x, double y)
        {
            return Execute("Div", new[] { x, y });
        }

        /// <summary>
        /// Разность
        /// </summary>
        /// <param name="x">Уменьшаемое</param>
        /// <param name="y">Вычитаемое</param>
        /// <returns>Разность</returns>
        public double Diff(double x, double y)
        {
            return Execute("Diff", new[] { x, y });
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Multiply(double x, double y)
        {
            return Execute("Multiply", new[] { x, y });
        }
    }
}
