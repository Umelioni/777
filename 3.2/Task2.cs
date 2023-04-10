using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _3._2
{
    class Task2
    {
        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public float Price { get; set; }
        }

        static void Main(string[] args)
        {
            string pathToDirectory = @"";

            Func<Product, bool> filter = p => p.Price > 50 && p.Category.Equals("Electronics");

            for (int i = 1; i <= 10; i++)
            {
                string filePath = Path.Combine(pathToDirectory, $"{i}.json");

                var products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(filePath));
                List<Product> filteredProducts = products.Where(filter).ToList();
                filteredProducts.ForEach(p => Console.WriteLine(p.Name));
            }
        }
    }
}
