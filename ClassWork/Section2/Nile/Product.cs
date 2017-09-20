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
        public readonly Product None = new Product();

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            // string get_Name ()
            get 
            {
                return _name ?? "";
            }

            // void set_Name ( string value )
            set 
            {
                _name = value?.Trim();
            }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public const decimal DiscontinuedDiscountRate = 0.10M;

        /// <summary>Gets the discounted price, if applicable.</summary>
        public decimal DiscountedPrice
        {
            get {
                //if (IsDiscontinued)
                if (this.IsDiscontinued)
                    return Price * DiscontinuedDiscountRate;

                return Price;
            }
        }

        public int ICanOnlySetIt { get; private set; }
        public int ICanOnlySetIt2 { get; }

        public void Foo( string name )
        {
            name = "Hello";
        }

        private string _name;
        private string _description;

        private readonly double _someValueICannotChange = 10;
    }
}
