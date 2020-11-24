using System;
using System.Collections.Generic;

namespace PermutationsWithoutRepetitions
{
    class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];
            Permute(0);
        }

        static void Permute(int index)
        {
            if (index >= elements.Length)
                Print();
            else
            {
                Permute(index + 1);
                var swapped = new HashSet<string> { elements[index] };
                for (int i = index + 1; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            string temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
            
        }


        private static void Print()
        {
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}