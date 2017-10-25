/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;

namespace Nile.Stores
{
    /// <summary>Provides a base implementation of <see cref="IProductDatabase"/>.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //Validate
            if (product == null)
                return null;

            if (!ObjectValidator.TryValidate(product, out var errors))
                return null;
            
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //Validate
            if (id <= 0)
                return null;

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            // Validate
            if (id <= 0)
                return;

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            // Validate
            if (product == null)
                return null;
            
            if (!ObjectValidator.TryValidate(product, out var errors))
                return null;
            
            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
                return null;

            return UpdateCore(existing, product);
        }

        #region Protected Members

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected abstract Product AddCore( Product product );

        /// <summary>Get a product given its ID.</summary>
        /// <param name="id">The ID.</param>
        /// <returns>The product, if any.</returns>
        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        /// <summary>Removes a product given its ID.</summary>
        /// <param name="id">The ID.</param>
        protected abstract void RemoveCore( int id );

        /// <summary>Updates a product.</summary>
        /// <param name="existing">The existing product.</param>
        /// <param name="newItem">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected abstract Product UpdateCore( Product existing, Product newItem );
        
        #endregion
    }
}
