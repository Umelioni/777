using System;
using System.IO;
using System.Linq;

namespace _2._1
{
    class Task1
    {
        static void Main(string[] args)
        {
            var students = File.ReadAllLines("students.csv")
                .Skip(1)
                .Select(line => 
                {
                    var columns = line.Split(',');
                    return (name: columns[0], grade: int.Parse(columns[1]), age: int.Parse(columns[2]));
                })
                .ToList();

            var filteredStudents = students.Where(student => student.grade >= 22);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.name} - {student.grade}");
            }
        }
    }
}
