using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFibonacci
{
    class Program
    {
        private static int[] numbers;
        static void Main(string[] args)
        {
            numbers = new int[50];
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(getFibonacci(n));
        }

        private static int getFibonacci(int n)
        {
            if (n == 0 || n == 1) return 1;
            if (numbers[n] != 0) return numbers[n];
            return numbers[n] = getFibonacci(n - 1) + getFibonacci(n - 2);
        }
    }
}
