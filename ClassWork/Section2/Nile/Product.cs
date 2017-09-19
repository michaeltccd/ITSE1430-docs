using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    /// <remarks>
    /// This will represent a product with other stuff.
    /// </remarks>
    public class Product
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name;

        /// <summary>Gets or sets the description.</summary>
        public string Description;

        /// <summary>Gets or sets the price.</summary>
        public decimal Price;

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued;
    }
}
