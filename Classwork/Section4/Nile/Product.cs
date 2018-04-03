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
            //Using expression bodies to save typing
            get => _description ?? "";
            set => _description = value ?? "";
            //get { return _description ?? ""; }
            //set { _description = value ?? ""; }
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value></value>
        public string Name
        {
            //Using expression bodies to save typing
            get => _name ?? "";
            set => _name = value;
            //get { return _name ?? ""; }
            //set { _name = value; }
        }
        
        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; }
        
        //Be very careful about lambda properties
        //private int SomeValue = 10;   //This is a field
        //private int SomeValue2 => 10; //This is a get only property

        //Using an expression body for getter only
        /// <summary>Gets the price, with any discontinued discounts.</summary>
        public decimal ActualPrice 
                => IsDiscontinued ? (Price - (Price* DiscountPercentage)) : Price; 
        //{
        //get { return IsDiscontinued ?
        //         (Price - (Price * DiscountPercentage)) : Price; }
        //{
        //    if (IsDiscontinued)
        //        return Price - (Price * DiscountPercentage);

        //    return Price;
        //}
        //}

        /// <summary>Determines if the product is discontinued.</summary>
        public bool IsDiscontinued { get; set; }
        
        /// <summary>Validate the product.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            //Name is required
            if (String.IsNullOrEmpty(_name))
                errors.Add(new ValidationResult("Name cannot be empty", 
                             new[] { nameof(Name) }));

            //Price >= 0
            if (Price < 0)
                errors.Add(new ValidationResult("Price must be >= 0",
                            new[] { nameof(Price) }));

            return errors;
        }

        #region Private Members

        internal decimal DiscountPercentage = 0.10M;

        private string _name;
        private string _description;

        #endregion
    }
}
