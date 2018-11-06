/*
 * ITSE1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itse1430.MovieLib.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using SQL Server.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        protected override void AddCore( Movie movie )
        {
            throw new NotImplementedException();
        }

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            throw new NotImplementedException();
        }

        protected override Movie FindByName( string name )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore( string name )
        {
            throw new NotImplementedException();
        }
    }
}
