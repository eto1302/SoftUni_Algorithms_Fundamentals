using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRight
{
    class Program
    {
        private static int[,] DPMAtrix;
        private static int[,] matrix;
        private static int height, width;
        private static List<KeyValuePair<int, int>> path;
        static void Main(string[] args)
        {
            ReadMatrix();
            GenerateDPMatrix();
            CreatePath();
            path.Reverse();
            Console.WriteLine(string.Join(" ", path.Select(a => $"[{a.Key}, {a.Value}]")));
        }

        private static void CreatePath()
        {

            int currentHeight = height - 1, currentWidth = width - 1;
            path.Add(new KeyValuePair<int, int>(currentHeight, currentWidth));
            while (currentWidth != 0 || currentHeight != 0)
            {
                if (currentWidth == 0)
                {
                    currentHeight--;
                }
                else if (currentHeight == 0)
                {
                    currentWidth--;
                }
                else
                {
                    if (DPMAtrix[currentHeight, currentWidth - 1] < DPMAtrix[currentHeight - 1, currentWidth])
                    {
                        currentHeight--;
                    }
                    else
                    {
                        currentWidth--;
                    }
                }

                path.Add(new KeyValuePair<int, int>(currentHeight, currentWidth));
            }
        }

        private static void GenerateDPMatrix()
        {
            DPMAtrix[0, 0] = matrix[0, 0];
            for (int i = 1; i < width; i++)
            {
                DPMAtrix[0, i] = DPMAtrix[0, i - 1] + matrix[0, i];
            }
            for (int i = 1; i < height; i++)
            {
                DPMAtrix[i, 0] = DPMAtrix[i - 1, 0] + matrix[i, 0];
            }

            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    DPMAtrix[i, j] = Math.Max(DPMAtrix[i - 1, j], DPMAtrix[i, j - 1]) + matrix[i, j];
                }
            }
        }

        private static void ReadMatrix()
        {
            height = int.Parse(Console.ReadLine());
            width = int.Parse(Console.ReadLine());
            matrix = new int[height, width];
            DPMAtrix = new int[height, width];
            path = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < height; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
        }
    }
}
