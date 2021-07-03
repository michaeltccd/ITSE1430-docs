/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System;
using System.Collections.Generic;

namespace MovieLibrary.Memory
{    
    /// <summary>Represents an in-memory movie database.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {        
        protected override Movie AddCore ( Movie movie )
        {                    
            //Add the movie
            movie.Id = ++_id;
            _movies.Add(CloneMovie(movie));

            return movie;
        }

        protected override void DeleteCore ( int id )
        {            
            var existing = FindById(id);
            if (existing != null)
                _movies.Remove(existing);
        }

        protected override Movie GetCore ( int id )
        {
            var existing = FindById(id);
            if (existing == null)
                return null;

            return CloneMovie(existing);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            foreach (var item in _movies)
                //Clone the movie so the caller can manipulate the movie without breaking our copy
                yield return CloneMovie(item);
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id) ?? throw new Exception("Movie does not exist.");

            //Update the movie
            CopyMovie(existing, movie);
        }

        private Movie CloneMovie ( Movie movie )
        {
            var target = new Movie() {
                Id = movie.Id
            };

            CopyMovie(target, movie);
            return target;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.ReleaseYear = source.ReleaseYear;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
        }

        private Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();

        private int _id;
    }
}
