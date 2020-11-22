using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_01_Vectors
{
    class Program
    {
        private static void Gen01(int[] array, int index)
        {
            if (index >= array.Length) Console.WriteLine(string.Join("", array));
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    array[index] = i;
                    Gen01(array, index + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Gen01(arr, 0);
        }
    }
}
