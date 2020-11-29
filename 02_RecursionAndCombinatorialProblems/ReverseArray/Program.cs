using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArray
{
    class Program
    {
        public static int[] array;
        static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            PrintArray(array.Length - 1);
        }

        private static void PrintArray(int index)
        {
            if (index < 0) return;
            Console.Write(array[index] + " ");
            PrintArray(index-1);
        }
    }
}
