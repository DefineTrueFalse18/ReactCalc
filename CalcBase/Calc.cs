using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;
using System.Reflection;
using System.IO;
using ReactCalc.Models;


namespace ReactCalc
{
    /// <summary>
    /// Калькулятро
    /// </summary>
    public class Calc
    {
        public string LastOperationName { get; set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            
            //добавляем базовые операции
			//(+,-,/,*)
            GetOperations("Basic");

            //добавляем dll-ки
            //директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Extensions");
            //если директория не найдена, то ничего не добавляем
            if (!Directory.Exists(extsDirectory))
                return;
            var exts = Directory.GetFiles(extsDirectory, "*dll");
            foreach (var dllName in exts)
            {
                GetOperations(dllName);
            }
        }

        private void GetOperations(string dllName)
        {
            if (!File.Exists(dllName) && dllName != "Basic")
            {
                return;
            }
            //загружаем сборку
            var assembly = dllName != "Basic"
                ? Assembly.LoadFrom(dllName)
                : Assembly.GetAssembly(typeof(ReactCalc.Models.IOperation));
            //получаем все типы/классы из нее
            var types = assembly.GetTypes();
            //перебираем типы
            var searchInterface = typeof(IOperation);
            foreach (var t in types)
            {
                var interfs = t.GetInterfaces();
                //находим тех кто реализует интерфейс ioperation
                if (interfs.Contains(searchInterface) && t.Name != "IDisplayOperation" && t.Name != "Operation")
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

        public IList<IOperation> Operations { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            //Находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {
                var displayOper = oper as IDisplayOperation;

                //displayOper.DisplayName != ""
                LastOperationName = displayOper != null
                    ? displayOper.DisplayName
                    : oper.Name;

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

        public static double toDouble(string arg)
        {

            double x = 0;
            double.TryParse(arg, out x);
            return x;
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
