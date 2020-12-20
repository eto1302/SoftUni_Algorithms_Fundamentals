using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;

namespace TwoMinutesToMidnight
{
    class Program
    {
        private static Dictionary<string, long> memoizationDictionary;
        static void Main(string[] args)
        {
            memoizationDictionary = new Dictionary<string, long>();
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinomialCoefficient(n,k));
        }

        private static long GetBinomialCoefficient(int n, int k)
        {
            if (memoizationDictionary.ContainsKey($"{n} {k}"))
            {
                return memoizationDictionary[$"{n} {k}"];
            }
            if (k == 0 || n == k) return 1;
            memoizationDictionary.Add($"{n} {k}", GetBinomialCoefficient(n - 1, k) + GetBinomialCoefficient(n - 1, k - 1));
            return memoizationDictionary[$"{n} {k}"];
        }
    }
}
