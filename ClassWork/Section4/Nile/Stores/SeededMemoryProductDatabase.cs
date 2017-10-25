/*
 * ITSE 1430
 */
using System;

namespace Nile.Stores
{
    /// <summary>Provides a <see cref="MemoryProductDatabase"/> with products already added.</summary>
    public class SeedMemoryProductDatabase : MemoryProductDatabase
    {
        /// <summary>Initializes an instance of the <see cref="SeedMemoryProductDatabase"/> class.</summary>
        public SeedMemoryProductDatabase ()
        {
            AddCore(new Product() { Id = 1, Name = "Galaxy S7", Price = 650 });
            AddCore(new Product() { Id = 2, Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true });
            AddCore(new Product() { Id = 3, Name = "Windows Phone", Price = 100 });
            AddCore(new Product() { Id = 4, Name = "iPhone X", Price = 1900, IsDiscontinued = true });
        }
    }
}
