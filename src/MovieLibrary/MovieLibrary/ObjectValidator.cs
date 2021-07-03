/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Validates an object.</summary>
    public static class ObjectValidator
    {        
        /// <summary>Attempts to validate an object.</summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>The validation results.</returns>
        public static List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }

        /// <summary>Validates an object.</summary>
        /// <param name="value">The value to validate.</param>
        public static void Validate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
