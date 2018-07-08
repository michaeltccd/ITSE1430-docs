/*
 * ITSE 1430
 * Classwork
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Provides information about a product.</summary>
    public class Product : IValidatableObject
    {   
        /// <summary>Gets or sets the product ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {            
            get => _description ?? "";          // { return _description ?? ""; }
            set => _description = value ?? "";  // { _description = value ?? ""; }
        }

        /// <summary>Gets or sets the name.</summary>
        //[RequiredAttribute]
        [Required(AllowEmptyStrings = false)]     
        //[StringLength(1)]
        public string Name
        {
            get => _name ?? "";        // { return _name ?? ""; }
            set => _name = value;      // { _name =  value; }
        }
        
        /// <summary>Gets or sets the price.</summary>
        [Range(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price { get; set; }
        
        /// <summary>Gets the price, with any discontinued discounts.</summary>
        public decimal ActualPrice 
                => IsDiscontinued ? (Price - (Price* DiscountPercentage)) : Price; 
        //{ get { return ...; } }

        /// <summary>Determines if the product is discontinued.</summary>
        public bool IsDiscontinued { get; set; }
        
        /// <summary>Validate the product.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            ////Name is required
            //if (String.IsNullOrEmpty(_name))
            //    errors.Add(new ValidationResult("Name cannot be empty", 
            //                 new[] { nameof(Name) }));

            //Price >= 0
            //if (Price < 0)
            //    errors.Add(new ValidationResult("Price must be >= 0",
            //                new[] { nameof(Price) }));

            return errors;
        }

        #region Private Members

        internal decimal DiscountPercentage = 0.10M;

        private string _name;
        private string _description;

        #endregion
    }
}
