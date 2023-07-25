/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
namespace MovieLibrary;

/// <summary>Represents a base implementation of movie database.</summary>
public abstract class MovieDatabase : IMovieDatabase
{
    /// <inheritdoc />
    public Movie Add ( Movie movie )
    {            
        //Validation
        if (movie == null)            
            throw new ArgumentNullException(nameof(movie));
        
        //Must be unique
        var existing = FindByTitle(movie.Title);
        if (existing != null)
            throw new InvalidOperationException("Movie title must be unique.");

        //Add the movie
        return AddCore(movie);
    }        

    /// <inheritdoc />
    public void Delete ( int id )
    {
        //Validation
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

        //Delete
        DeleteCore(id);
    }        

    /// <inheritdoc />
    public Movie Get ( int id )
    {
        //Validation
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

        //Get
        return GetCore(id);
    }        

    /// <inheritdoc />
    public IEnumerable<Movie> GetAll ()
    {
        //Will never return null
        return GetAllCore() ?? Enumerable.Empty<Movie>();
    }

    /// <inheritdoc />
    public void Update ( int id, Movie movie )
    {
        //Validation
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

        if (movie == null)
            throw new ArgumentNullException(nameof(movie));
        
        ObjectValidator.Validate(movie);

        //Must be unique
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
             throw new InvalidOperationException("Movie title must be unique.");

        try
        {
            UpdateCore(id, movie);
        } catch (ArgumentException)
        {
            throw;
        } catch (InvalidOperationException)
        {
            throw;
        } catch (Exception e)
        {             
            throw new Exception("Update failed", e);
        };
    }

    #region Protected Members

    /// <summary>Adds the movie to the database.</summary>
    /// <param name="movie">The movie to add.</param>
    /// <returns>The new movie.</returns>
    protected abstract Movie AddCore ( Movie movie );

    /// <summary>Deletes a movie.</summary>
    /// <param name="id">The movie to delete.</param>
    protected abstract void DeleteCore ( int id );

    /// <summary>Finds a movie by its title.</summary>
    /// <param name="title">The title to find (case insensitive).</param>
    /// <returns>The movie, if any.</returns>
    /// <remarks>
    /// The default implementation enumerates all the movies.
    /// </remarks>
    protected virtual Movie FindByTitle ( string title )
    {
        foreach (var item in GetAllCore())
        {
            //Match movie by title, case insensitive
            if (String.Compare(item.Title, title, true) == 0)
                return item;
        };

        return null;
    }


    /// <summary>Gets all the movies.</summary>
    /// <returns>The movies.</returns>
    protected abstract IEnumerable<Movie> GetAllCore ();

    /// <summary>Gets a movie.</summary>
    /// <param name="id">The ID of the movie.</param>
    /// <returns>The movie, if any.</returns>
    protected abstract Movie GetCore ( int id );

    /// <summary>Updates a movie.</summary>
    /// <param name="id">ID of the movie.</param>
    /// <param name="movie">The movie.</param>
    protected abstract void UpdateCore ( int id, Movie movie );
    #endregion
}
