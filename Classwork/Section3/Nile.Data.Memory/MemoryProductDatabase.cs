/*
 * ITSE1430  
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {
        /// <summary>Initializes an instance of the <see cref="MemoryProductDatabase"/> class.</summary>
        public MemoryProductDatabase()
        {
            //Array version
            //var prods = new Product[]
            //var prods = new []
            //    {
            //        new Product(),
            //        new Product()
            //    };

            //_products = new Product[25];
            _products = new List<Product>() 
            {
                new Product() { Id = _nextId++, Name = "iPhone X",
                                IsDiscontinued = true, Price = 1500, },
                new Product() { Id = _nextId++, Name = "Windows Phone",
                                IsDiscontinued = true, Price = 15, },
                new Product() { Id = _nextId++, Name = "Samsung S8",
                                IsDiscontinued = false, Price = 800 }
            };

            //var product = new Product() {
            //    Id = _nextId++,
            //    Name = "iPhone X",
            //    IsDiscontinued = true,
            //    Price = 1500,
            //};
            //_products.Add(product);

            //product = new Product() {
            //    Id = _nextId++,
            //    Name = "Windows Phone",
            //    IsDiscontinued = true,
            //    Price = 15,
            //};
            //_products.Add(product);

            //product = new Product {
            //    Id = _nextId++,
            //    Name = "Samsung S8",
            //    IsDiscontinued = false,
            //    Price = 800
            //};
            //_products.Add(product);
        }
        
        protected override Product AddCore ( Product product )
        {
            // Clone the object
            product.Id = _nextId++;
            _products.Add(Clone(product));

            // Return a copy
            return product;
        }

        protected override Product GetCore( int id )
        {
            //for (var index = 0; index < _products.Length; ++index)
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            //Iterator syntax
            foreach (var product in _products)
            {
                if (product != null)
                    yield return Clone(product);
            };
        }
        
        protected override void RemoveCore ( int id )
        {
            var existing = GetCore(id);
            if (existing != null)
                _products.Remove(existing);
        }

        protected override Product UpdateCore ( Product product )
        {
            var existing = GetCore(product.Id);

            // Clone the object
            //_products[existingIndex] = Clone(product);
            Copy(existing, product);

            //Return a copy
            return product;
        }

        protected override Product GetProductByNameCore( string name )
        {
            foreach (var product in _products)
            {
                //product.Name.CompareTo
                if (String.Compare(product.Name, name, true) == 0)
                    return product;
            };

            return null;
        }

        #region Private Members

        //Clone a product
        private Product Clone ( Product item )
        {
            var newProduct = new Product();
            Copy(newProduct, item);

            return newProduct;
        }

        //Copy a product from one object to another
        private void Copy ( Product target, Product source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.IsDiscontinued = source.IsDiscontinued;
        }

        //private int FindEmptyProductIndex()
        //{
        //    for (var index = 0; index < _products.Length; ++index)
        //    {
        //        if (_products[index] == null)
        //            return index;
        //    };

        //    return -1;
        //}

        //Find a product by its ID
                
        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;

        #endregion
    }
}
