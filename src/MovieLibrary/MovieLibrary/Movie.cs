/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieLibrary
{        
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Where you put additional comments that may be useful to someone.
    /// </remarks>
    public class Movie : IValidatableObject
    {
        /// <summary>Defines the minimum release year.</summary>
        public const int MinimumReleaseYear = 1900;

        /// <summary>Defines the minimum release date.</summary>
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);


        /// <summary>Unique identifier of the movie.</summary>
        public int Id { get; set; }

        /// <summary>Gets the age of the movie in years.</summary>
        public int AgeInYears => (DateTime.Today.Year < ReleaseYear) ? 0 : DateTime.Today.Year - ReleaseYear;

        /// <summary>Gets or sets the title.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Title //()
        {
            get => _title ?? "";
            set => _title = value?.Trim() ?? "";
        }        

        /// <summary>Gets or sets the description.</summary>        
        [StringLength(100)]
        public string Description
        {
            get => _description ?? "";
            set => _description = value;
        }
        
        /// <summary>Gets or sets the release year.</summary>
        [RangeAttribute(1900, 2100)]
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        /// <summary>Gets or sets the run length.</summary>
        [RangeAttribute(0, Int32.MaxValue, ErrorMessage = "Run length must be greater than or equal to 0.")]
        public int RunLength { get; set; }

        /// <summary>Gets or sets the rating.</summary>
        [RequiredAttribute(AllowEmptyStrings = false)]
        public string Rating
        {
            get => _rating ?? "";
            set => _rating = value;
        }

        /// <summary>Gets or sets the classic indicator.</summary>
        public bool IsClassic { get; set; }

        /// <inheritdoc />
        public override string ToString () => Title;

        /// <inheritdoc />
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext ) => Enumerable.Empty<ValidationResult>();

        #region Private Members

        private string _title = "";
        private string _description = "";
        private string _rating = "";
        #endregion
    }
}
