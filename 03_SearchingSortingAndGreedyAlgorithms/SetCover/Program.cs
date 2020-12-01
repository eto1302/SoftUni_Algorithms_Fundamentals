using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            List<int[]> sets = new List<int[]>();
            var selectedSets = new List<int[]>();
            int end = int.Parse(Console.ReadLine());
            for (int i = 0; i < end ; i++)
            {
                  sets.Add(Console.ReadLine().Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            while (universe.Count > 0)
            {
                var currentSet = sets.OrderByDescending(s => s.Count(
                    e => universe.Contains(e))).FirstOrDefault();
                selectedSets.Add(currentSet);
                sets.Remove(currentSet);
                foreach (var a in currentSet)
                {
                    universe.Remove(a);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{string.Join(", ", set)}");
            }
        }
    }
}
