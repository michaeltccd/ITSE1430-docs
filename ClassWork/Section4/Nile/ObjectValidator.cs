/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Validate objects.</summary>
    public class ObjectValidator
    {
        /// <summary>Tries to validate an object.</summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="errors">The list of errors.</param>
        /// <returns>true if validation succeeded or false otherwise.</returns>
        public static bool TryValidate ( IValidatableObject value, out IEnumerable<ValidationResult> errors )
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationResult>();

            errors = results;
            return Validator.TryValidateObject(value, context, results);
        }
    }
}
