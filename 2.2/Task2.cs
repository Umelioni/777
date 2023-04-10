using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    class Task2
    {
        static void Main(string[] args)
        {
            var employees = new List<(string name, int salary)>
            {
                ("Alex", 1232),
                ("Bob", 4567),
                ("ChatGPT", 44444),
            };

            var sortedEmployees = employees.OrderBy(employee => employee.salary);

            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.name} - {employee.salary}");
            }
        }
    }
}
