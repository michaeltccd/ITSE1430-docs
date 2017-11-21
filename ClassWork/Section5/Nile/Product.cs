/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    /// <remarks>
    /// This will represent a product with other stuff.
    /// </remarks>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            get => _name ?? "";
            set => _name = value?.Trim();
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get => _description ?? "";
            set => _description = value?.Trim();
        }

        //Calculated property
        //public decimal CalculatedProperty
        //{
        //    get => 0M;
        //}

        //Getter only property with expression body
        //public decimal CalculatedProperty => 0M;

        //Field, oops, with expression body
        //public decimal CalculatedProperty2 = 0M;

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        //public override string ToString()
        //{
        //    return Name;
        //}

        public override string ToString() => Name;

        /// <summary>Validates the object.</summary>
        /// <returns>The error message or null.</returns>      
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Name cannot be empty
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name cannot be empty.", new[] { nameof(Name) });

            //Price >= 0
            if (Price < 0)
                yield return new ValidationResult("Price must be >= 0.", new[] { nameof(Price) });
        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
