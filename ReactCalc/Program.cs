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
            Console.WriteLine("Hello, i'm Калькулятор");

            int x = 0;
            int y = 0;
            var calc = new Calc();

            if(args.Length == 2) 
            {
                x = ToInt(args[0], x);
                y = ToInt(args[1], y);
            }
            else
            {
                #region Ввод данных

                Console.WriteLine("Input X:");
                var strx = Console.ReadLine();
                x = ToInt(strx, x);

                Console.WriteLine("Input Y:");
                var stry = Console.ReadLine();
                y = 0;
                y = ToInt(stry, y);
                #endregion
            }

            

            var result = calc.Sum(x,y);

            Console.WriteLine("Sum = " + result.ToString());

            Console.ReadKey();
        }

        /// <summary>
        /// Парсинг в инт
        /// </summary>
        /// <param name="arg">строка с первым эл-ом</param>
        /// <param name="def">тип int с результатом перевода строки в инт(100-дефолтное значения если не удалось распарсить)</param>
        /// <returns></returns>
        private static int ToInt(string arg, int def = 100) 
        {
            int x;
            if (!int.TryParse(arg, out x))
            {
                x = def;
            }
            return x;
        }
    }
}
