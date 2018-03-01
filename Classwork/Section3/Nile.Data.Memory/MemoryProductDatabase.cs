using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database.</summary>
    public class MemoryProductDatabase
    {
        public MemoryProductDatabase()
        {
            _products = new Product[25];

            var product = new Product();
            product.Name = "iPhone X";
            product.IsDiscontinued = true;
            product.Price = 1500;
            _products[0] = product;

            product = new Product();
            product.Name = "Windows Phone";
            product.IsDiscontinued = true;
            product.Price = 15;
            _products[1] = product;

            product = new Product();
            product.Name = "Samsung S8";
            product.IsDiscontinued = false;
            product.Price = 800;
            _products[2] = product;
        }

        public Product Add ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            };

            //TODO: Verify unique product

            //Add
            var index = FindEmptyProductIndex();
            if (index < 0)
            {
                message = "Out of memory";
                return null;
            };

            //TODO: Clone the object
            _products[index] = product;
            message = null;

            //TODO: Return a copy
            return product;
        }

        public Product Edit ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            };

            //TODO: Verify unique product except current product

            //Find existing
            var existingIndex = GetById(product.Id);
            if (existingIndex < 0)
            {
                message = "Product not found.";
                return null;
            };

            //TODO: Clone the object
            _products[existingIndex] = product;
            message = null;

            //TODO: Return a copy
            return product;
        }

        public Product[] GetAll ()
        {
            //TODO: Return a copy so caller cannot change the underlying data
            return _products;
        }

        public void Remove ( int id )
        {
            if (id > 0)
            {
                var index = GetById(id);
                if (index >= 0)
                    _products[index] = null;
            };
        }

        private int FindEmptyProductIndex()
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] == null)
                    return index;
            };

            return -1;
        }

        private int GetById ( int id )
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index]?.Id == id)
                    return index;
            };

            return -1;
        }

        private Product[] _products;
    }
}
