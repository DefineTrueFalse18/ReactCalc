using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello, i'm ReactCalc");
                Console.WriteLine("Choose action: Sum, Diff, Multiply, Div, Sqrt, Pow, Factorial");
                var choose = Console.ReadLine();

                var calc = new Calc();

                double x = 0.0;
                double y = 0.0;
                string inputStr = "";

                if (args.Length == 2)
                {
                    x = toDouble(args[0], x);
                    y = toDouble(args[1], y);
                }
                else
                {
                    inputStr = inputData();
                    x = toDouble(inputStr.Substring(0, inputStr.IndexOf(";")), x);
                    y = toDouble(inputStr.Substring(inputStr.IndexOf(";") + 1, inputStr.Length - (inputStr.IndexOf(";") + 1)), x);
                }

                try
                {
                    Console.WriteLine(calc.Execute(choose, new[] { x, y })); //сюда передавать еще 1 параметр( имя функции на русском)
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Press any key to the next calculations");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Парсинг в double
        /// </summary>
        /// <param name="arg">строка с первым эл-ом</param>
        /// <param name="def">тип double с результатом перевода строки в double(100-дефолтное значения если не удалось распарсить)</param>
        /// <returns></returns>
        private static double toDouble(string arg, double def = 100)
        {

            double x = 0;
            double.TryParse(arg, out x);
            return x;
        }

        /// <summary>
        /// Ввод данных
        /// </summary>
        /// <returns></returns>
        private static string inputData()
        {
            var strx = "";
            var stry = "";
            bool flag_check = false;

            while (!((checkInputData(strx, flag_check) == "Success") && (checkInputData(stry, flag_check) == "Success")))
            {
                Console.WriteLine("Enter X:");
                strx = Console.ReadLine();

                Console.WriteLine("Enter Y:");
                stry = Console.ReadLine();

                flag_check = true;
            }

            return strx + ";" + stry;
        }

        /// <summary>
        /// Проверка на правильность ввода чисел
        /// </summary>
        /// <param name="strCheck">Строка с данными</param>
        private static string checkInputData(string strCheck, bool flagCheck)
        {
            if (flagCheck)
            {
                double resCheckInt;
                if (!double.TryParse(strCheck, out resCheckInt))
                {
                    Console.WriteLine("Invalid data, enter an integer or double! ERROR in this data ----> " + strCheck );
                    return "Error";
                }
                else return "Success";
            }
            else return "This's first the first run without rows! Don't worry, BE HAPPY!";
        }
    }
}
