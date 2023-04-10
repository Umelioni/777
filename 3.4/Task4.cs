using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4
{
    class Task4
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Вкажіть шлях до файлів");
                return;
            }

            Func<string, IEnumerable<string>> tokenizer = (string input) =>
            {
                return input.Split(new char[] { ' ', '.', ',', ';', ':', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            };

            Func<IEnumerable<string>, IDictionary<string, int>> wordCounter = (IEnumerable<string> tokens) =>
            {
                var dictionary = new Dictionary<string, int>();
                foreach (var token in tokens)
                {
                    if (dictionary.ContainsKey(token))
                    {
                        dictionary[token]++;
                    }
                    else
                    {
                        dictionary[token] = 1;
                    }
                }
                return dictionary;
            };

            var fileNames = args.ToList();
            var wordFrequencies = new List<IDictionary<string, int>>();
            foreach (var fileName in fileNames)
            {
                var fileContents = File.ReadAllText(fileName);
                var tokens = tokenizer(fileContents);
                var wordFrequency = wordCounter(tokens);
                wordFrequencies.Add(wordFrequency);
            }

            Action<IDictionary<string, int>> wordFrequencyReporter = (IDictionary<string, int> wordFrequency) =>
            {
                foreach (var pair in wordFrequency)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            };

            foreach (var wordFrequency in wordFrequencies)
            {
                Console.WriteLine("Статистика частоти слів:");
                wordFrequencyReporter(wordFrequency);
                Console.WriteLine();
            }
        }
    }
}
