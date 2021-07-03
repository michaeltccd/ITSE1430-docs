/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    /// <summary>Represents a database of movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="movie"/>Movie is not unique.</exception>
        Movie Add ( Movie movie );

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than one.</exception>
        void Delete ( int id );

        /// <summary>Gets a movie, if any.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than one.</exception>
        Movie Get ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>Updates an existing movie.</summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie.</param>
        /// <exception cref="Exception">Movie does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than one.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="movie"/>Movie is not unique.</exception>
        void Update ( int id, Movie movie );
    }
}