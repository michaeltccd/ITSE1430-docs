/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Memory
{
    /// <summary>Represents a database of movies.</summary>
    public class ArrayMovieDatabase
    {
        public Movie Add ( Movie movie, out string error )
        {
            //Validation
            //  Check for null and valid movie
            if (movie == null)
            {
                error = "Movie is null";
                return null;
            };

            var results = ObjectValidator.TryValidate(movie);
            if (results.Any())
            {
                error = results[0].ErrorMessage;
                return null;
            };

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                error = "Movie title must be unique";
                return null;
            };

            //Add the movie
            _movies[0] = CloneMovie(movie);

            error = null;
            return movie;
        }

        public Movie[] GetAll ()
        {
            var items = new Movie[_movies.Length];

            int index = 0;
            foreach (var item in _movies)
                //Clone the movie so the caller can manipulate the movie without breaking our copy
                items[index++] = CloneMovie(item);

            return items;
        }

        private Movie CloneMovie ( Movie movie )
        {
            var target = new Movie();
            target.Title = movie.Title;
            target.Description = movie.Description;
            target.ReleaseYear = movie.ReleaseYear;
            target.Rating = movie.Rating;
            target.RunLength = movie.RunLength;
            target.IsClassic = movie.IsClassic;

            return target;
        }

        private Movie FindByTitle ( string title )
        {
            return null;
        }
        
        private Movie[] _movies = new Movie[100];
    }
}
