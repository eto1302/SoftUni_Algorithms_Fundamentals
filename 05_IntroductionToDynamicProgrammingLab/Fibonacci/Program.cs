using System;

namespace Fibonacci
{
    class Program
    {
        public static long[] fibonacciNumber;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibonacciNumber = new long[200000];
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            fibonacciNumber[0] = 1;
            fibonacciNumber[1] = 1;
            SolveFibonacci(n - 1);
            Console.WriteLine(fibonacciNumber[n - 1]);
        }

        private static long SolveFibonacci(int n)
        {
            if (fibonacciNumber[n - 1] == 0)
            {
                fibonacciNumber[n - 1] = SolveFibonacci(n - 1);
            }

            if (fibonacciNumber[n - 2] == 0)
            {
                fibonacciNumber[n - 2] = SolveFibonacci(n - 2);
            }

            fibonacciNumber[n] = fibonacciNumber[n - 1] + fibonacciNumber[n - 2];
            return fibonacciNumber[n];
        }
    }
}
