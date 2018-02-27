/*
 * ITSE 1430
 * Classwork
 */
using System;

namespace Nile
{
    /// <summary>Provides information about a product.</summary>
    public class Product
    {   
        /// <summary>Gets or sets the product ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value ?? ""; }
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value></value>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        
        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; }

        /// <summary>Gets the price, with any discontinued discounts.</summary>
        public decimal ActualPrice
        {
            get 
            {
                if (IsDiscontinued)
                    return Price - (Price * DiscountPercentage);

                return Price;
            }
        }

        /// <summary>Determines if the product is discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        /// <summary>Validates the product.</summary>
        /// <returns>Error message, if any.</returns>
        public string Validate ()
        {
            //Name is required
            if (String.IsNullOrEmpty(_name))
                return "Name cannot be empty";

            //Price >= 0
            if (Price < 0)
                return "Price must be >= 0";

            return "";
        }

        #region Private Members

        internal decimal DiscountPercentage = 0.10M;

        private string _name;
        private string _description;

        #endregion
    }
}
