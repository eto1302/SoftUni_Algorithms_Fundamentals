using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveArraySum
{
    class Program
    {
        
        private static int Sum(int[]array, int currentSum, int currentIndex)
        {
            if (currentIndex == array.Length) return currentSum;
            return Sum(array, currentSum += array[currentIndex], currentIndex + 1);
        }
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Sum(array, 0, 0));
        }
    }
}
