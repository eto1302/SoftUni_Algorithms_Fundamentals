using System;
using System.Collections.Generic;
using System.Linq;

namespace Time
{
    class Program
    {
        public static List<int> numbersInSequence;
        static void Main(string[] args)
        {
            var firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var DPMatrix = FillMatrix(firstNumbers, secondNumbers);
            var longestSubsequence = DPMatrix[firstNumbers.Length, secondNumbers.Length];
            numbersInSequence.Reverse();
            Console.WriteLine(string.Join(" ", numbersInSequence));
            Console.WriteLine(longestSubsequence);
        }

        private static int[,] FillMatrix(int[] firstNumbers, int[] secondNumbers)
        {
            var DPMatrix = new int[firstNumbers.Length + 1, secondNumbers.Length + 1];
            numbersInSequence = new List<int>();
            int max = 0;
            for (int i = 1; i < DPMatrix.GetLength(0); i++)
            {
                for (int j = 1; j < DPMatrix.GetLength(1); j++)
                {
                    if (firstNumbers[i - 1] == secondNumbers[j - 1])
                    {
                        DPMatrix[i, j] = DPMatrix[i - 1, j - 1] + 1;
                        if (DPMatrix[i, j] > max)
                        {
                            max = DPMatrix[i, j];
                            numbersInSequence.Add(firstNumbers[i-1]);
                        }
                    }
                    else
                    {
                        DPMatrix[i, j] = Math.Max(DPMatrix[i - 1, j], DPMatrix[i, j - 1]);
                    }
                }
            }

            var row = firstNumbers.Length;
            var col = secondNumbers.Length;
            numbersInSequence.Clear();
            while (row > 0 && col > 0)
            {
                if (firstNumbers[row - 1] == secondNumbers[col - 1])
                {
                    numbersInSequence.Add(firstNumbers[row - 1]);
                    row--;
                    col--;
                }
                else if (DPMatrix[row, col - 1] >= DPMatrix[row - 1, col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }
            

            return DPMatrix;
        }
    }
}
