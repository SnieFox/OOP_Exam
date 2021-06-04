using System;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace OOP_Exam
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введите число, до которого осуществлять поиск: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Parallel.Invoke(
                () =>
                {
                    FibonacciNumbers fibonacci = new FibonacciNumbers(n);
                    Thread firstThread = new Thread(fibonacci.ProcessNumbers);
                    firstThread.Start();
                },

                () =>
                {
                    PrimeNumbers simple = new PrimeNumbers(n);
                    Thread secondThread = new Thread(simple.ProcessNumbers);
                    secondThread.Start();
                }
            );

        }

    }
}
