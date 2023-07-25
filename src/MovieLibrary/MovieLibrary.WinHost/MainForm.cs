/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using Microsoft.Extensions.Configuration;

namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    #region Construction

    public MainForm ()
    {
        InitializeComponent();                            
    }
    #endregion

    protected override void OnLoad ( EventArgs e )
    {
        base.OnLoad(e);

        var movies = _database.GetAll();
        if (movies.Count() == 0)
        {
            if (MessageBox.Show(this, "Do you want to seed the database?", "Seed Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                _database.Seed();
        };

        UpdateUI();
    }

    private void OnHelpAbout ( object sender, EventArgs e )
    {
        var form = new AboutBox();
        
        form.ShowDialog();
    }

    private void OnFileExit ( object sender, EventArgs e )
    {
        //Display a confirmation and quit if yes
        var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
            return;

        Close();
    }

    private void OnMovieAdd ( object sender, EventArgs e )
    {
        var form = new MovieDetailForm();

        do
        {
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            try
            {
                //Save the movie
                _database.Add(form.Movie);                    
                break;
            } catch (ArgumentException)
            {
                DisplayError("Add Failed", "You didn't pass the args right");
            } catch (Exception ex)
            {                    
                DisplayError("Add Failed", ex.Message);
            };                
        } while (true);

        UpdateUI();
    }

    private void DisplayError ( string title, string message )
    {
        MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void OnMovieDelete ( object sender, EventArgs e )
    {
        //If a movie exists then display confirmation and delete
        var movie = GetSelectedMovie();
        if (movie == null)
            return;

        var result = MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
            return;

        try
        {
            _database.Delete(movie.Id);
        } catch (Exception ex)
        {
            DisplayError("Delete Failed", ex.Message);
        };

        UpdateUI();
    }
            
    private void OnMovieEdit ( object sender, EventArgs e )
    {
        //If a movie exists then display confirmation and delete
        var movie = GetSelectedMovie();
        if (movie == null)
            return;

        var form = new MovieDetailForm();
        form.Movie = movie;

        do
        {
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //Save the movie
            try
            {
                _database.Update(movie.Id, form.Movie);
                break;
            } catch (Exception ex)
            {
                DisplayError("Add Failed", ex.Message);
            };
        } while (true);

        UpdateUI();
    }

    #region Private Members

    private Movie GetSelectedMovie ()
    {
        return lstMovies.SelectedItem as Movie;
    }

    private void UpdateUI ()
    {
        lstMovies.DisplayMember = "Title";

        try
        {
            var movies = from m in _database.GetAll()
                         orderby m.Title, m.ReleaseYear
                         select m;

            //Can bind listbox using Items or DataSource            
            lstMovies.DataSource = movies.ToArray();                
        } catch (Exception e)
        {
            DisplayError("Error retrieving movies", e.Message);

            lstMovies.DataSource = new Movie[0];
        };                                         
    }

    private readonly IMovieDatabase _database = new SqlServer.SqlServerMovieDatabase(Program.Configuration.GetConnectionString("AppDatabase"));

    #endregion
}
