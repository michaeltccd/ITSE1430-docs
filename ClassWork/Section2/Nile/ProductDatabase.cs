using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Base class for product database.</summary>
    public class ProductDatabase
    {
        public ProductDatabase ()
        {
            var product = new Product();
            product.Name = "Galaxy S7";
            product.Price = 650;
            Add(product);

            product = new Product();
            product.Name = "Samsung Note 7";
            product.Price = 150;
            product.IsDiscontinued = true;
            Add(product);

            product = new Product();
            product.Name = "Windows Phone";
            product.Price = 100;
            Add(product);

            product = new Product();
            product.Name = "iPhone X";
            product.Price = 1900;
            product.IsDiscontinued = true;
            Add(product);
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Validate
            if (product == null)
                return null;
            if (!String.IsNullOrEmpty(product.Validate()))
                return null;

            //Emulate database by storing copy
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);
            newProduct.Id = _nextId++;

            return CopyProduct(newProduct);

            //var item = _list[0];

            //TODO: Implement Add
            //return product;
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public Product[] GetAll ()
        {
            var items = new Product[_products.Count];
            var index = 0;
            foreach (var product in _products)
                items[index++] = CopyProduct(product);

            return items;
            //How many products?
            //var count = 0;
            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        ++count;
            //};

            //var items = new Product[count];
            //var index = 0;

            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        //product = new Product();
            //        items[index++] = CopyProduct(product);
            //};

            //return items;
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;

            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);

            //if (_list[index].Name == product.Name)
            //{
            //    _list.RemoveAt(index);
            //    break;
            //};        
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            //TODO: Validate
            if (product == null)
                return null;
            if (!String.IsNullOrEmpty(product.Validate()))
                return null;

            //Get existing product
            var existing = FindProduct(product.Id);
            if (existing == null)
                return null;

            //Replace 
            _products.Remove(existing);
            
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }

        private Product CopyProduct ( Product product )
        {
            if (product == null)
                return null;

            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        //private Product[] _products = new Product[100];
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
        //private List<int> _ints;
    }
}
