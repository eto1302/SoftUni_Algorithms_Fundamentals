using System;
using System.Collections.Generic;
using System.Data;

namespace LongestCommonSubsequence
{
    class Program
    {
        public static string str1, str2;
        public static int[,] lcs;
        public static void Main(string[] args)
        {
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            var lcs = new int[str1.Length + 1, str2.Length + 1];
            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r,c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }
            var sequence = new List<char>();
            int row = str1.Length;
            int col = str2.Length;
            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1] && lcs[row, col] == lcs[row - 1, col - 1] + 1)
                {
                    sequence.Add(str1[row - 1]);

                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine(string.Join("", sequence).Length);
        }
    }
}
