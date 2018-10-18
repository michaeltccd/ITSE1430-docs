/*
 * ITSE 1430 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itse1430.MovieLib
{
    /// <summary>Provides extensions for <see cref="MovieDatabase"/>.</summary>
    public static class SeedDatabase
    {
        /// <summary>Seeds a database.</summary>
        /// <param name="database">The database to seed.</param>
        public static void Seed ( MovieDatabase database )
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
            Seed(database, movies);
        }

        /// <summary>Seeds a database.</summary>
        /// <param name="database">The database to seed.</param>
        /// <param name="movies">The movies to seed with.</param>
        public static void Seed ( MovieDatabase database, Movie[] movies )
        {
            foreach (var movie in movies)
                database.Add(movie);
        }
    }
}
