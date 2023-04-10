using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Task3
    {
        public delegate int @delegate(int x, int y, int o);
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            @delegate @delegate = (x, y, o) => x * y * o / 3;
            Console.WriteLine(@delegate(t, p, b));
        }
    }
}
