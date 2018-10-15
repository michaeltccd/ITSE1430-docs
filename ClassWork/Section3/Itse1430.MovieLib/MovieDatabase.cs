using System;
using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    /// <summary>Manages a set of movies.</summary>
    public class MovieDatabase
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <remarks>
        /// The database is seeded with some movies.
        /// </remarks>
        public MovieDatabase() : this(true)
        {
        }

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <param name="seed">true to seed the database with movies.</param>        
        public MovieDatabase( bool seed ) : this(GetSeedMovies(seed))
        {
            //Ctor chaining eliminates the need to replicate this logic
            //if (seed)
            //{
            //    var movie = new Movie();
            //    movie.Name = "Jaws";
            //    movie.RunLength = 120;
            //    movie.ReleaseYear = 1977;
            //    Add(movie);

            //    movie = new Movie();
            //    movie.Name = "What About Bob?";
            //    movie.RunLength = 96;
            //    movie.ReleaseYear = 2004;
            //    Add(movie);
            //};
        }

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <param name="movies">The list of movies to initialize the database with.</param>
        public MovieDatabase( Movie[] movies )
        {
            _items.AddRange(movies);
            //for (var index = 0; index < movies.Length; ++index)
            //    _movies[index] = movies[index];
        }
        #endregion

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        public void Add( Movie movie )
        {
            _items.Add(movie);
            //var index = FindNextFreeIndex();
            //if (index >= 0)
            //    _movies[index] = movie;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        public Movie[] GetAll()
        {
            //How many movies do we have
            var count = _items.Count;

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _items)
            {
                temp[index++] = movie;
            };

            return temp;
        }

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        public void Edit( string name, Movie movie )
        {
            //Find movie by name
            Remove(name);

            //Replace it
            Add(movie);
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        public void Remove( string name )
        {
            var movie = FindMovie(name);
            if (movie != null)
                _items.Remove(movie);
        }

        #region Private Members

        private Movie FindMovie( string name )
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

        //Gets some movies to see database with
        private static Movie[] GetSeedMovies( bool seed )
        {
            if (!seed)
                return new Movie[0];

            return new [] {
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
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _items = new List<Movie>();
        #endregion
    }
}
