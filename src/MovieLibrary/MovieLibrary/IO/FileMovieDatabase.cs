/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
namespace MovieLibrary.IO;

/// <summary>Represents an in-memory movie database.</summary>
public class FileMovieDatabase : Memory.MemoryMovieDatabase
{
    #region Construction

    public FileMovieDatabase ( string filename ) => _filename = filename;

    #endregion

    protected override Movie AddCore ( Movie movie )
    {
        //Find highest ID in use
        var movies = GetAllCore();
        var id = GetHighestId(movies);

        movie.Id = ++id;

        //Union the results
        movies = movies.Union(new[] { movie });
        
        SaveMovies(movies);
        return movie;
    }

    protected override void DeleteCore ( int id )
    {
        //Does not remove the item correctly...
        var movies = GetAllCore().ToList();

        var movie = FindById(movies, id);
        if (movie != null)
            movies.Remove(movie);

        SaveMovies(movies);
    }

    protected override Movie GetCore ( int id )
    {
        //Open the file
        using (var reader = File.OpenText(_filename))
        {
            //Read each line
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var movie = LoadMovie(line);
                if (movie?.Id == id)
                    return movie;
            };
        };            

        return null;
    }

    protected override IEnumerable<Movie> GetAllCore ()
    {
        var movies = LoadMovies();

        return movies;
    }

    protected override void UpdateCore ( int id, Movie movie )
    {
        var movies = GetAllCore().ToArray();

        var existing = FindById(movies, id);
        if (existing == null)
            throw new Exception("Movie not found");

        existing.Title = movie.Title;
        existing.Rating = movie.Rating;
        existing.ReleaseYear = movie.ReleaseYear;
        existing.RunLength = movie.RunLength;
        existing.IsClassic = movie.IsClassic;
        existing.Description = movie.Description;

        SaveMovies(movies);            
    }

    #region Private Members

    private Movie FindById ( IEnumerable<Movie> items, int id ) => items.FirstOrDefault(x => x.Id == id);

    private int GetHighestId ( IEnumerable<Movie> items )
    {            
        return items.Any() ? items.Max(x => x.Id) : 0;
    }


    //Buffered IO
    private IEnumerable<Movie> LoadMovies ()
    {
        if (File.Exists(_filename))
        {
            var movies = from line in File.ReadAllLines(_filename)
                         let movie = LoadMovie(line)
                         where movie != null
                         orderby movie.Title, movie.ReleaseYear descending
                         select movie;
            return movies;
        };

        return Enumerable.Empty<Movie>();
    }

    private Movie LoadMovie ( string line )
    {
        //Id, Title, Rating, ReleaseYear, RunLength, IsClassic, Description
        var tokens = line.Split(','); 
        if (tokens.Length != 7)
            return null;

        var movie = new Movie() {
            Id = Int32.Parse(tokens[0].Trim()),
            Title = tokens[1].Trim().Trim('"'),
            Rating = tokens[2].Trim().Trim('"'),
            ReleaseYear = Int32.Parse(tokens[3].Trim()),
            RunLength = Int32.Parse(tokens[4].Trim()),
            IsClassic = Int32.Parse(tokens[5].Trim()) != 0,
            Description = tokens[6].Trim().Trim('"')
        };

        return movie;
    }

    private void SaveMovies ( IEnumerable<Movie> items )
    {
        var lines = items.Select(SaveMovie);

        File.WriteAllLines(_filename, lines);
    }

    private string SaveMovie ( Movie movie )
    {
        var fields = new [] { //new string[] {
                            movie.Id.ToString(),
                            QuoteString(movie.Title),
                            QuoteString(movie.Rating),
                            movie.ReleaseYear.ToString(),
                            movie.RunLength.ToString(),
                            (movie.IsClassic ? "1" : "0"),
                            QuoteString(movie.Description),
                    };

        return String.Join(',', fields);
    }

    private string QuoteString ( string value )
    {
        if (String.IsNullOrEmpty(value))
            return "\"\"";

        var hasStartingQuote = value.StartsWith('"');
        var hasEndingQuote = value.EndsWith('"');

        //If no starting quote but might have ending quote then wrap it
        if (!hasStartingQuote)
            return "\"" + value + (hasEndingQuote ? "" : "\"");
        else if (!hasEndingQuote)  //Has starting quote but no ending quote
            return value + "\"";

        return value;   //Has starting and ending quote
    }

    private readonly string _filename;

    #endregion
}
