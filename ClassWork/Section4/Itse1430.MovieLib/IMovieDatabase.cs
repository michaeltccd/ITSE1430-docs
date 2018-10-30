/*
 * ITSE1430
 */
using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    /// <summary>Provides an interface for accessing movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        void Add( Movie movie );

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        void Edit( string name, Movie movie );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        IEnumerable<Movie> GetAll();

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        void Remove( string name );
    }
}