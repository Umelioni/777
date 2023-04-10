using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3
{
    class Task3
    {
        static void Main(string[] args)
        {
            var products = new List<(string name, string category, float price)>
            {
                ("Apply", "Fruit", 2.33f),
                ("Banana", "Fruit", 1.33f),
                ("Carrot", "Vegetable", 0.66f),
                ("Potato", "Vegetable", 0.55f),
            };


            var groupedProducts = products.GroupBy(product => product.category);

            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var product in group)
                {
                    Console.WriteLine($"    {product.name}: {product.price}");
                }
            }
        }
    }
}
