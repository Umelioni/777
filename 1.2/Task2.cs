using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    class Task2
    {
        public delegate int @delegate();

        public static int Methods(@delegate[] array)
        {
            int x = 1;
            foreach (@delegate del in array)
            {
                x *= del();
            }
            x /= array.Length;
            Console.WriteLine(x);
            return x;
        }

        public static int ForArray()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 10);
            Console.WriteLine(x);
            return x;
        }

        static void Main(string[] args)
        {
            @delegate del = Task2.ForArray;
            @delegate del2 = Task2.ForArray;
            @delegate[] dels = new @delegate[2];
            dels[0] = del;
            dels[1] = del2;
            Methods(dels);
        }
    }
}
