/*
 * ITSE 1430
 */
using System;

namespace Nile.Stores
{
    /// <summary>Provides extensions for <see cref="IProductDatabase"/>.</summary>
    public static class ProductDatabaseExtensions
    {
        /// <summary>Adds seed data to a database.</summary>
        /// <param name="database">The data to seed.</param>
        public static void WithSeedData ( IProductDatabase database )
        {
            database.Add(new Product() { Name = "Galaxy S7", Price = 650 });
            database.Add(new Product() { Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true });
            database.Add(new Product() { Name = "Windows Phone", Price = 100 });
            database.Add(new Product() { Name = "iPhone X", Price = 1900, IsDiscontinued = true });
        }
    }
}
