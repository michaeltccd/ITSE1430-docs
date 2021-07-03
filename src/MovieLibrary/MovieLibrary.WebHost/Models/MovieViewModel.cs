/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.WebHost.Models
{
    public class MovieViewModel
    {
        public MovieViewModel ()
        {
        }

        public MovieViewModel ( Movie movie )
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Rating = movie.Rating;
            ReleaseYear = movie.ReleaseYear;
            RunLength = movie.RunLength;
            IsClassic = movie.IsClassic;
        }

        public Movie ToMovie ()
        {
            return new Movie() {
                Id = Id,
                Title = Title,
                Description = Description,
                Rating = Rating,
                ReleaseYear = ReleaseYear,
                RunLength = RunLength,
                IsClassic = IsClassic
                };
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [RequiredAttribute(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        [RangeAttribute(1900, 2100)]
        public int ReleaseYear { get; set; }

        [RangeAttribute(0, Int32.MaxValue, ErrorMessage = "Run length must be greater than or equal to 0")]
        public int RunLength { get; set; }

        public bool IsClassic { get; set; }
    }
}
