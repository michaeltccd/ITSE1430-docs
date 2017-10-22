using System.Collections.Generic;

namespace Nile
{
    /// <summary>Provides a database of <see cref="Product"/> items.</summary>
    public interface IProductDatabase
    {
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        Product Add( Product product );

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        Product Get( int id );

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        IEnumerable<Product> GetAll();

        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        void Remove( int id );

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        Product Update( Product product );
    }
}