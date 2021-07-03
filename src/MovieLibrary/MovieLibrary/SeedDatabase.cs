/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;

namespace MovieLibrary
{
    /// <summary>Provides extensions for seeding a database.</summary>
    public static class SeedDatabase
    {
        /// <summary>Seeds a database.</summary>        
        /// <param name="database">The database to seed.</param>
        /// <remarks>
        /// Assumes the database is empty.
        /// </remarks>
        public static void Seed ( this IMovieDatabase database )
        {            
            var movie1 = new Movie() {
                Title = "Jaws",
                Description = "The original shark movie",
                Rating = "PG",
                ReleaseYear = 1979,
                RunLength = 123
            };

            var movie2 = new Movie() {
                Title = "Jaws 2",
                Rating = "PG-13",
                ReleaseYear = 1981,
                RunLength = 156,
            };

            var movie3 = new Movie() {
                Title = "Dune",
                Rating = "PG",
                ReleaseYear = 1985,
                RunLength = 210
            };

            database.Add(movie1);
            database.Add(movie2);
            database.Add(movie3);
        }
    }
}
