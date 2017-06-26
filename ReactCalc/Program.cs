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
                Console.WriteLine("Choose action: 1-Sum, 2-Div, 3-Square root, 4-Difference, Another key-EXIT");
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

                switch (choose)
                {
                    case "1":
                        var result = calc.Sum(x, y);
                        Console.WriteLine("Sum = " + result.ToString());
                        result = 0;
                        break;

                    case "2":
                        if (y == 0)
                        {
                            Console.WriteLine("Division by zero is impossible!");
                            break;
                        }
                        result = calc.Div(x, y);
                        Console.WriteLine("Div = " + result.ToString());
                        result = 0;
                        break;

                    case "3":
                        Console.WriteLine("Choose X or Y: 1-X, 2-Y");
                        string strChoose = Console.ReadLine();

                        while (strChoose != "1" && strChoose != "2")
                        {
                            Console.WriteLine("Enter valid variant 1 or 2:");
                            strChoose = Console.ReadLine();
                        }

                        if (strChoose == "1")
                        {
                            if (x < 0)
                            {
                                Console.WriteLine("Square root of a negative number impossible!");
                                break;
                            }

                            result = calc.SquareRoot(x);
                            Console.WriteLine("Square root = " + result.ToString());
                            result = 0;
                            break;
                        }
                        else
                        {
                            if (y < 0)
                            {
                                Console.WriteLine("Square root of a negative number impossible!");
                                break;
                            }

                            result = calc.SquareRoot(y);
                            Console.WriteLine("Square root = " + result.ToString());
                            result = 0;
                            break;
                        }

                    case "4":
                        result = calc.Diff(x, y);
                        Console.WriteLine("Difference = " + result.ToString());
                        result = 0;
                        break;

                    default:
                        Environment.Exit(0);
                        break;
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
                    Console.WriteLine("Invalid data, enter an integer!");
                    return "Error";
                }
                else return "Success";
            }
            else return "This's first the first run without rows! Don't worry, BE HAPPY!";
        }
    }
}
