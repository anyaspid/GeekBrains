using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddSum
{
    class Program
    {
        static bool String2Int(string sInput, ref int riOutput)
        {
            bool bParseResult = int.TryParse(sInput, out riOutput);
            return bParseResult;
        }

        static void Main(string[] args)
        {
            List<int> liOddNumbers = new List<int>();
            int iNumber = 0;
            bool bWrongData;

            Console.Title = "Summarize odd numbers 1.0";
            Console.WriteLine("Данная программа анализирует введенные числа и подсчитывает сумму нечетных.");
            Console.WriteLine("Для внесения данных пожалуйста вводите числа по одному за строку. Для завершения ввода введите 0.");

            do
            {
                if (!String2Int(Console.ReadLine(), ref iNumber))
                {
                    Console.WriteLine("Неверный формат ввода, пожалуйста вводите одно число в строку, подтверждая ввод клавишей Enter.");
                    bWrongData = true;
                }
                else
                {
                    if (iNumber % 2 != 0) { liOddNumbers.Add(iNumber); }
                    bWrongData = false;
                }
            }
            while ((iNumber != 0) ^ bWrongData);

            

            Console.Write("Следующие из введенных чисел являются нечетными: ");
            foreach (int iOddNumber in liOddNumbers)    { Console.Write("{0} ", iOddNumber); }
            Console.WriteLine("\nСумма введенных чисел составляет: {0}", liOddNumbers.Sum());

            //Pause
            Console.ReadKey();

        }
    }
}
