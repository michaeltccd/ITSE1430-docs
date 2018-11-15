/*
 * ITSE1430
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itse1430.MovieLib.Memory
{
    /// <summary>Manages a set of movies.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        protected override void AddCore( Movie movie )
        {
            _items.Add(movie);
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        protected override IEnumerable<Movie> GetAllCore()
        {
            return from item in _items
                   select new Movie() {
                    Name = item.Name,
                    Description = item.Description,
                    ReleaseYear = item.ReleaseYear,
                    RunLength = item.RunLength,
                    IsOwned = item.IsOwned
                };       
        }

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        protected override void EditCore ( Movie oldMovie, Movie newMovie )
        {
            //Find movie by name
            _items.Remove(oldMovie);

            //Replace it
            _items.Add(newMovie);
        }

        /// <summary>Finds a movie by its name.</summary>
        /// <param name="name">The name of the movie.</param>
        /// <returns>The movie, if any.</returns>
        protected override Movie FindByName( string name )
        {
            return (from m in _items
                    where String.Compare(name, m.Name, true) == 0
                    select m).FirstOrDefault();
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        protected override void RemoveCore ( string name )
        {
            var movie = FindByName(name);
            if (movie != null)
                _items.Remove(movie);
        }

        #region Private Members
                      
        private List<Movie> _items = new List<Movie>();
        #endregion
    }
}
