/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itse1430.MovieLib
{
    [Description("A movie.")]
    public class Movie : IValidatableObject
    {
        //-Attribute is optional, compiler will add it
        //() are optional when calling default constructor
        [Required(AllowEmptyStrings = false)]
        //[Required()]
        //[RequiredAttribute()]
        //[StringLength(100, MinimumLength = 1)]
        public string Name
        {
            //Using expression body
            //get { return _name ?? ""; }  // string get ()
            get => _name ?? "";

            //Using expression body
            //set { _name = value; }       // void set ( string value )
            set => _name = value;
        }

        private string _name = "";
               
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }        

        private string _description;

        //Multiple attributes can be specified in separate blocks
        //or in same block separated by commas
        [Range(1900, 2100, ErrorMessage = "Release year must be >= 1900.")]
        //[Required]
        //[RangeAttribute(1900, 2100), RequiredAttribute()]
        public int ReleaseYear { get; set; } = 1900;
        
        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        public int RunLength { get; set; }
        
        public int Id { get; set; }

        public bool IsColor => ReleaseYear > 1940;
        
        public bool IsOwned { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //if (String.IsNullOrEmpty(Name))
            //    yield return new ValidationResult("Name is required.",
            //                    new[] { nameof(Name) });

            //if (ReleaseYear < 1900)
            //    yield return new ValidationResult("Release year must be >= 1900",
            //                    new[] { nameof(ReleaseYear) });

            //if (RunLength < 0)
            //    yield return new ValidationResult("Run length must be >= 0",
            //                    new[] { nameof(RunLength) });
            yield return null;
        }        
    }
}
