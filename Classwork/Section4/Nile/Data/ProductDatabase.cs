/*
 * ITSE1430  
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Data
{
    /// <summary>Provides a base implementation of <see cref="IProductDatabase"/>.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Add a new product.</summary>
        /// <param name="product">The product to add.</param>
        /// <param name="message">Error message.</param>
        /// <returns>The added product.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        /// <exception cref="Exception">A product with the same name already exists.</exception>
        /// <remarks>
        /// Returns an error if product is null, invalid or if a product
        /// with the same name already exists.
        /// </remarks>
        public Product Add ( Product product )
        {
            //Check for null
            //if (product == null)
                //throw new ArgumentNullException(nameof(product));
            product = product ?? throw new ArgumentNullException(nameof(product));

            //Validate product 
            product.Validate();
            //var errors = product.TryValidate();
            //var error = errors.FirstOrDefault();
            //if (error != null)
            //{
            //    message = error.ErrorMessage;
            //    return null;
            //};

            // Verify unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null)
                throw new Exception("Product already exists");
            //{
            //    message = "Product already exists.";
            //    return null;
            //};
            
            return AddCore(product);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The list of products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <summary>Removes a product.</summary>
        /// <param name="id">The product ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        public void Remove ( int id )
        {
            //Return an error if id <= 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");

            //if (id > 0)
            //{
                RemoveCore(id);
            //};
        }

        /// <summary>Edits an existing product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        /// <exception cref="Exception">A product with the same name already exists.</exception>
        /// <exception cref="ArgumentException">The product does not exist.</exception>
        /// <remarks>
        /// Returns an error if product is null, invalid, product name
        /// already exists or if the product cannot be found.
        /// </remarks>
        public Product Update ( Product product )
        {
            //Check for null
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            //{
            //    message = "Product cannot be null.";
            //    return null;
            //};

            //Validate product 
            product.Validate();
            //var errors = product.TryValidate();
            //var error = errors.FirstOrDefault();
            //if (error != null)
            //{
            //    message = error.ErrorMessage;
            //    return null;
            //};

            // Verify unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null && existing.Id != product.Id)
                throw new Exception("Product already exists");
            //{
            //    message = "Product already exists.";
            //    return null;
            //};

            //Find existing
            existing = existing ?? GetCore(product.Id);
            if (existing == null)
                throw new ArgumentException("Product not found", nameof(product));
            //{
            //    message = "Product not found.";
            //    return null;
            //};

            return UpdateCore(product);
        }

        protected abstract Product AddCore( Product product );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product GetCore( int id );
        protected abstract void RemoveCore( int id );
        protected abstract Product UpdateCore( Product product );
        protected abstract Product GetProductByNameCore( string name );
    }
}
