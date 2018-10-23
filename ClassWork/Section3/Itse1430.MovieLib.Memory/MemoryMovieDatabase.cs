/*
 * ITSE1430
 */
using System;
using System.Collections.Generic;

namespace Itse1430.MovieLib.Memory
{
    /// <summary>Manages a set of movies.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        protected override void AddCore ( Movie movie )
        {
            _items.Add(movie);
            //var index = FindNextFreeIndex();
            //if (index >= 0)
            //    _movies[index] = movie;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        protected override IEnumerable<Movie> GetAllCore()
        {
            return _items;
            ////How many movies do we have
            //var count = _items.Count;

            //var temp = new Movie[count];
            //var index = 0;
            //foreach (var movie in _items)
            //{
            //    temp[index++] = movie;
            //};

            //return temp;
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
            //Example with multiple type parameters
            //var pairs = new Dictionary<string, Movie>();

            //for (var index = 0; index < _movies.Length; ++index)
            foreach (var movie in _items)
            {
                //if (String.Compare(name, _movies[index]?.Name, true) == 0)
                if (String.Compare(name, movie.Name, true) == 0)
                    return movie;
            };

            return null;
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
                      
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _items = new List<Movie>();
        #endregion
    }
}
