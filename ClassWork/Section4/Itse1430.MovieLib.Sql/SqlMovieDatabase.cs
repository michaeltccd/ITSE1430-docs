/*
 * ITSE1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Itse1430.MovieLib.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using SQL Server.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            //Validate
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty."
                            , nameof(connectionString));

            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override void AddCore( Movie movie )
        {
            //var conn = new SqlConnection(_connectionString);
            
            #region Approaches to adding parameters
            //Approach 1
            //var param = new SqlParameter("@title", System.Data.SqlDbType.VarChar);
            //param.Value = movie.Name;
            //cmd.Parameters.Add(param);

            //Approach 2
            //var param = cmd.Parameters.Add("@title", System.Data.SqlDbType.VarChar);
            //param.Value = movie.Name;
            #endregion

            //Approach 3            

            //Run command
            //try
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", movie.Name);
                cmd.Parameters.AddWithValue("@length", movie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);
                cmd.Parameters.AddWithValue("@description", movie.Description);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);
            };
            /*} finally
            {
                conn.Close();
            };*/
        }

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            using (var conn = CreateConnection())
            {
                //var cmd = new SqlCommand("AddMovie", conn);
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(oldMovie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", newMovie.Name);
                cmd.Parameters.AddWithValue("@length", newMovie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", newMovie.IsOwned);
                cmd.Parameters.AddWithValue("@description", newMovie.Description);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        private object GetMovieId( Movie oldMovie )
        {
            return 1;
        }

        protected override Movie FindByName( string name )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            //throw new NotImplementedException();
            return new Movie[0];
        }

        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie == null)
                return;

            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(movie);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        private SqlConnection CreateConnection()
                => new SqlConnection(_connectionString);
    }
}
