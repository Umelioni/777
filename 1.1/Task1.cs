using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1
{
    class Task1
    {
        public delegate int Math(int x, int y);

        static void Main(string[] args)
        {
            Console.Write("First number: ");
            int f = int.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            int s = int.Parse(Console.ReadLine());
            Math math = (x, y) => x + y;
            Console.WriteLine($"+: {math(f, s)}");
            math += (x, y) => x - y;
            Console.WriteLine($"-: {math(f, s)}");
            math += (x, y) => x * y;
            Console.WriteLine($"*: {math(f, s)}");
            math += (x, y) =>
            {
                int d = 0;
                try
                {
                    d = x / y;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
                return d;
            };
            Console.WriteLine($"/: {math(f, s)}");
        }
    }
}
