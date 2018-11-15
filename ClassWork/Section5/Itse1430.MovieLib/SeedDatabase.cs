/*
 * ITSE 1430 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itse1430.MovieLib
{
    /// <summary>Provides extensions for <see cref="MovieDatabase"/>.</summary>
    public static class MovieDatabaseExtensions
    {        
        /// <summary>Seeds a database.</summary>
        /// <param name="source">The database to seed.</param>
        /// <remarks>
        /// Extension method to see a database.
        /// </remarks>
        public static void Seed ( this IMovieDatabase source )
        {
            var movies = new[] {
                new Movie() {
                    Name = "Jaws",
                    RunLength = 120,
                    ReleaseYear = 1977,
                },
                new Movie() {
                    Name = "What About Bob?",
                    RunLength = 96,
                    ReleaseYear = 2004,
                },
            };
            Seed(source, movies);
        }

        /// <summary>Seeds a database.</summary>
        /// <param name="source">The database to seed.</param>
        /// <param name="movies">The movies to seed with.</param>
        /// <remarks>
        /// Extension method to see a database.
        /// </remarks>
        public static void Seed ( this IMovieDatabase source, Movie[] movies )
        {
            foreach (var movie in movies)
                source.Add(movie);
        }
    }
}
