/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Nile.Stores
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"/> using a memory collection.</summary>
    public class FileProductDatabase : MemoryProductDatabase
    {        
        public FileProductDatabase ( string filename )
        {
            //Validate argument
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty.", nameof(filename));

            _filename = filename;

            LoadFile(filename);
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = base.AddCore(product);

            SaveFile(_filename);

            return newProduct;
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            base.RemoveCore(id);

            SaveFile(_filename);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {
            var newProduct = base.UpdateCore(existing, product);
            SaveFile(_filename);

            return newProduct;
        }

        private void LoadFile ( string filename )
        {
            if (!File.Exists(filename))
                return;

            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                    continue;

                var fields = line.Split(',');
                var product = new Product() {
                    Id = Int32.Parse(fields[0]),
                    Name = fields[1],
                    Description = fields[2],
                    Price = Decimal.Parse(fields[3]),
                    IsDiscontinued = Boolean.Parse(fields[4])
                };

                base.AddCore(product);
            };
        }

        private void SaveFile ( string filename )
        {
            //Streaming
            //StreamWriter writer = null;
            //var stream = File.OpenWrite(filename);
            //try
            //{
            //    //Write stuff
            //    writer = new StreamWriter(stream);                
            //} finally
            //{
            //    writer?.Dispose();
            //    stream.Close();
            //};            
            using (var writer = new StreamWriter(filename))
            {
                //Write stuff
                foreach (var product in GetAllCore())
                {
                    var row = String.Join(",", product.Id, product.Name, 
                                          product.Description, product.Price, product.IsDiscontinued);

                    writer.WriteLine(row);
                };
            };
        }

        private readonly string _filename;
    }
}
