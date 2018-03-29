using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data
{
    /// <summary>Provides extension methods for <see cref="IProductDatabase"/>.</summary>
    public static class ProductDatabaseExtensions
    {
        /// <summary>Seeds the database.</summary>
        /// <param name="source">The source.</param>
        public static void Seed ( this IProductDatabase source )
        {            
            source.Add(new Product() {
                Name = "iPhone X",
                IsDiscontinued = true,
                Price = 1500, });
            source.Add(new Product() {
                Name = "Windows Phone",
                IsDiscontinued = true,
                Price = 15, });
            source.Add(new Product() {
                Name = "Samsung S8",
                IsDiscontinued = false,
                Price = 800
            });
        }
    }
}
