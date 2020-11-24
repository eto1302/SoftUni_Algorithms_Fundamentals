using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] combinations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            combinations = new string[n];
            Comb(0, 0);
        }

        private static void Comb(int index, int start)
        {
            if (index >= combinations.Length)
            {
                Print();
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    Comb(index + 1, i + 1);
                }
            }

        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", combinations));
        }
    }
}
