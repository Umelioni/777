using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    class Task1
    {
        static void Main(string[] args)
        {
            CSVReader cSVReadering = new CSVReader("test.csv");
            cSVReadering.Read();
        }
    }
    public class CSVReader
    {
        string path = "";
        public CSVReader(string path) => this.path = path;
        public void Read()
        {
            if (this.path == string.Empty) return;

            string dateFormat = "yyyy-MM-dd";
            int batchCount = 10;

            Func<string, DateTime> func = d => DateTime.ParseExact(d, dateFormat, null);

            Func<string, double> func1 = d => double.Parse(d);

            Action<DateTime, double> printTotal = (date, total) =>
            Console.WriteLine("{0}: {1}", date.ToString(dateFormat), total);

            var transactions = File.ReadLines(this.path)
           .Select(line => line.Split(','))
           .GroupBy(cols => func(cols[0]));

            foreach (var group in transactions)
            {
                double total = group.Sum(cols => func1(cols[1]));

                printTotal(group.Key, total);

                if (group.Count() >= batchCount)
                {
                    Write(group, dateFormat);
                }
            }
        }

        public void Write(IGrouping<DateTime, string[]> group, string dateFormat)
        {
            if (this.path == string.Empty) return;

            string backupFilePath = string.Format("{0}_{1}.bak", this.path, group.Key.ToString(dateFormat));

            File.Copy(this.path, backupFilePath, true);

            using (var writer = new StreamWriter(this.path))
            {
                foreach (var cols in group)
                {
                    writer.WriteLine(string.Join(",", cols));
                }
            }
        }
    }
    
}
