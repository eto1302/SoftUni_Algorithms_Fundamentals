using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDrawing
{
    class Program
    {
        private static void Draw(int beginning, int end, char symbol)
        {
            if (symbol == '*')
            {
                if (beginning == end) return;
                Console.WriteLine(new string(symbol, beginning));
                Draw(beginning - 1, end, symbol);
            }
            if (symbol == '#')
            {
                if (beginning == end) return;
                Console.WriteLine(new string(symbol, beginning));
                Draw(beginning+1, end, symbol);
            }
        }
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Draw(length, 0, '*');
            Draw(1, length + 1, '#');
        }
    }
}
