using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4
{
    class Task4
    {
        delegate int @delegate(string str);

        static void Main(string[] args)
        {
            string[] words = { "background", "word", "group", "database" };

            @delegate stringLength = s => s.Length;

            foreach (string word in words)
            {
                int length = stringLength(word);
                Console.WriteLine($"{word}: {length}");
            }
        }
    }
}
