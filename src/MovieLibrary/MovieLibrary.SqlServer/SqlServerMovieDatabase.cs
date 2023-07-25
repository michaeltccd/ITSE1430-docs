/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.SqlServer;

/// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using SQL Server.</summary>
/// <remarks>
/// Relies on ADO.NET for database access.
/// </remarks>
public class SqlServerMovieDatabase : MovieDatabase
{
    public SqlServerMovieDatabase ( string connectionString )
    {
        _connectionString = connectionString;
    }

    protected override Movie AddCore ( Movie movie )
    {
        using (var conn = OpenConnection())
        {
            var cmd = new SqlCommand("AddMovie", conn) {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@name", movie.Title));
            cmd.Parameters.AddWithValue("@rating", movie.Rating);
            cmd.Parameters.AddWithValue("@description", movie.Description);
            cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
            cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
            cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

            object result = cmd.ExecuteScalar();

            movie.Id = Convert.ToInt32(result);
        };

        return movie;
    }

    private SqlConnection OpenConnection ()
    {
        //Connect to db using SqlConnection
        var conn = new SqlConnection(_connectionString);            
        conn.Open();

        return conn;
    }

    protected override void DeleteCore ( int id )
    {
        using (var conn = OpenConnection())
        {
            var cmd = new SqlCommand("DeleteMovie", conn) {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            //No result expected
            cmd.ExecuteNonQuery();
        };
    }

    protected override Movie FindByTitle ( string title )
    {
        using (var conn = OpenConnection())
        {
            var cmd = new SqlCommand("FindByName", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", title);

            using (var reader = cmd.ExecuteReader())
            {
                //Reads next row, if any
                while (reader.Read())
                {
                    return new Movie() {
                        Id = (int)reader[0],
                        Title = (string)reader["Name"],
                        Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Rating = reader.GetString("Rating"),                //Preferred
                        ReleaseYear = reader.GetFieldValue<int>(4),
                        RunLength = reader.GetFieldValue<int>("RunLength"),
                        IsClassic = reader.GetFieldValue<bool>("IsClassic") //Preferred
                    };
                };
            };
        };

        return null;
    }

    protected override Movie GetCore ( int id )
    {
        using (var conn = OpenConnection())
        {
            var cmd = new SqlCommand("GetMovie", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            using (var reader = cmd.ExecuteReader())
            {
                //Reads next row, if any
                while (reader.Read())
                {
                    return new Movie() {
                        Id = (int)reader[0],
                        Title = (string)reader["Name"],
                        Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Rating = reader.GetString("Rating"),                //Preferred
                        ReleaseYear = reader.GetFieldValue<int>(4),
                        RunLength = reader.GetFieldValue<int>("RunLength"),
                        IsClassic = reader.GetFieldValue<bool>("IsClassic") //Preferred
                    };
                };
            };
        };

        return null;
    }

    protected override IEnumerable<Movie> GetAllCore ()
    {
        using (var conn = OpenConnection())
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "GetMovies";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var ds = new DataSet();
            var da = new SqlDataAdapter() {
                SelectCommand = cmd
            };

            //Fill the dataset
            da.Fill(ds);

            //Get first table, if any, and then enumerate the rows
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {                       
                    yield return new Movie() {
                        Id = (int)row[0],
                        Title = (string)row["Name"],
                        Description = row.IsNull(2) ? null : (string)row[2],
                        Rating = row.Field<string>("Rating"), //Preferred
                        RunLength = row.Field<int>("RunLength"),
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic")
                    };
                };
            };
        };
    }

    protected override void UpdateCore ( int id, Movie movie )
    {
        using (var conn = OpenConnection())
        {
            var cmd = new SqlCommand("UpdateMovie", conn) {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            
            cmd.Parameters.Add(new SqlParameter("@name", movie.Title));
            cmd.Parameters.AddWithValue("@rating", movie.Rating);
            cmd.Parameters.AddWithValue("@description", movie.Description);
            cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
            cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
            cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.ExecuteNonQuery();
        };
    }

    private readonly string _connectionString;
}
