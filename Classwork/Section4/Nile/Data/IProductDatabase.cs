/*
 * ITSE 1430
 */
using System.Collections.Generic;

namespace Nile.Data
{
    /// <summary>Provides access to products.</summary>
    public interface IProductDatabase
    {
        /// <summary>Adds a product to the database.</summary>
        /// <param name="product">The product to add.</param>
        /// <param name="message">The error message, if any.</param>
        /// <returns>The added product.</returns>
        /// <remarks>
        /// Generates an error if:
        /// <paramref name="product"/> is null or invalid.
        /// A product with the same name already exists.
        /// </remarks>
        Product Add( Product product, out string message );

        /// <summary>Gets all the products.</summary>
        /// <returns>The list of products.</returns>
        IEnumerable<Product> GetAll();

        /// <summary>Removes a product.</summary>
        /// <param name="id">The ID of the project.</param>
        /// <remarks>
        /// Returns an error if <paramref name="id"/> is less than or
        /// equal to zero.
        /// </remarks>
        void Remove( int id );

        /// <summary>Updates an existing product in the database.</summary>
        /// <param name="product">The product to update.</param>
        /// <param name="message">The error message, if any.</param>
        /// <returns>The updated product.</returns>
        /// <remarks>
        /// Generates an error if:
        /// <paramref name="product"/> is null or invalid.
        /// A product with the same name already exists.
        /// The product does not exist.
        /// </remarks>
        Product Update( Product product, out string message );                
    }
}