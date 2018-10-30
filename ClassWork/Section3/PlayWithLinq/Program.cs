using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithLinq
{
    class Program
    {
        static void Main( string[] args )
        {
            var products = GetProducts();

            //Get discounted products
            //var discounted = products.Where(IsDiscounted);
            var discounted = products.Where(p => p.IsDiscounted);

            var expensive = products.FirstOrDefault(p => p.Price > 100);

            //Demoing statement lambda rather than expression lambda
            var discountedExpensive = products.Where(p => {
                return p.IsDiscounted && p.Price > 100;
            });

            var subsetProducts = products.Select(p => 
                        new { Name = p.Name, Price = p.Price });

            var expensiveSubset = subsetProducts.Where(p => p.Price > 100);
        }

        //static bool IsDiscounted ( Product product )
        //{
        //    return product.IsDiscounted;
        //}

        static IEnumerable<Product> GetProducts ()
        {
            return new[] {
                new Product() { Name = "Product A", Price = 50, IsDiscounted = false },
                new Product() { Name = "Product B", Price = 150, IsDiscounted = true },
                new Product() { Name = "Product C", Price = 75, IsDiscounted = false },
                new Product() { Name = "Product D", Price = 105, IsDiscounted = true },
                new Product() { Name = "Product E", Price = 95, IsDiscounted = false },
                new Product() { Name = "Product F", Price = 5, IsDiscounted = true },
                new Product() { Name = "Product G", Price = 10, IsDiscounted = false },
                new Product() { Name = "Product H", Price = 200, IsDiscounted = true },
            };
        }
    }

    class Product
    {
        public string Name { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal Price { get; set; }
    }
}
