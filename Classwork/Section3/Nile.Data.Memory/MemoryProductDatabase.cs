using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database.</summary>
    public class MemoryProductDatabase
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

        /// <summary>Add a new product.</summary>
        /// <param name="product">The product to add.</param>
        /// <param name="message">Error message.</param>
        /// <returns>The added product.</returns>
        /// <remarks>
        /// Returns an error if product is null, invalid or if a product
        /// with the same name already exists.
        /// </remarks>
        public Product Add ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            //var error = product.Validate();
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                //Get first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            //TODO: Verify unique product

            //Add
            //var index = FindEmptyProductIndex();
            //if (index < 0)
            //{
            //    message = "Out of memory";
            //    return null;
            //};

            // Clone the object
            product.Id = _nextId++;
            _products.Add(Clone(product));
            message = null;

            // Return a copy
            return product;
        }

        /// <summary>Edits an existing product.</summary>
        /// <param name="product">The product to update.</param>
        /// <param name="message">Error message.</param>
        /// <returns>The updated product.</returns>
        /// <remarks>
        /// Returns an error if product is null, invalid, product name
        /// already exists or if the product cannot be found.
        /// </remarks>
        public Product Edit ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            //var error = product.Validate();
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                //Get first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            //TODO: Verify unique product except current product

            //Find existing
            var existing = GetById(product.Id);
            if (existing == null)
            {
                message = "Product not found.";
                return null;
            };

            // Clone the object
            //_products[existingIndex] = Clone(product);
            Copy(existing, product);
            message = null;

            //Return a copy
            return product;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The list of products.</returns>
        public Product[] GetAll ()
        {
            //Return a copy so caller cannot change the underlying data
            var items = new List<Product>();

            //for (var index = 0; index < _products.Length; ++index)
            foreach (var product in _products)
            {
                if (product != null)                
                    items.Add(Clone(product));
            };

            return items.ToArray();
        }

        /// <summary>Removes a product.</summary>
        /// <param name="id">The product ID.</param>
        public void Remove ( int id )
        {
            //TODO: Return an error if id <= 0

            if (id > 0)
            {
                var existing = GetById(id);
                if (existing != null)
                    _products.Remove(existing);
            };
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
        private Product GetById ( int id )
        {
            //for (var index = 0; index < _products.Length; ++index)
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;

        #endregion
    }
}
