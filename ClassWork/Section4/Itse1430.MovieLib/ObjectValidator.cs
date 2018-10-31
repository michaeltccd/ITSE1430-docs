/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itse1430.MovieLib
{
    /// <summary>Provides support for validating objects.</summary>
    public static class ObjectValidator
    {
        /// <summary>Validates an object.</summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>The list of validation results.</returns>
        public static IEnumerable<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            Validator.TryValidateObject(value, context, results, true);

            return results;
        }

        public static void Validate( IValidatableObject value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
