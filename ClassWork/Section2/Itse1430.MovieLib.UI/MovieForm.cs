using System;
using System.Windows.Forms;

namespace Itse1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        #region Construction

        public MovieForm()
        {
            InitializeComponent();
        }
        #endregion

        public Movie Movie { get; set; }

        private void MovieForm_Load( object sender, EventArgs e )
        {
            //_btnSave.Click += _btnSave_Click;
            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };
        }

        private void _btnSave_Click( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        #region Event Handlers

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            var movie = new Movie();
            
            //Name is required
            movie.Name = _txtName.Text;
            if (String.IsNullOrEmpty(movie.Name))
                return;

            movie.Description = _txtDescription.Text;

            //Release year is numeric, if set
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            if (movie.ReleaseYear < 0)
                return;

            //Run length, if set
            movie.RunLength = GetInt32(_txtRunLength);            
            if (movie.RunLength < 0)
                return;

            movie.IsOwned = _chkOwned.Checked;

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();

            //Using properties so don't need the method calls
            //movie.SetName(_txtName.Text);
            //movie.SetDescription(_txtDescription.Text);
            //movie.SetReleaseYear(GetInt32(_txtReleaseYear));
            //if (movie.GetReleaseYear() < 0)
            //movie.SetRunLength(GetInt32(_txtRunLength));
            //if (movie.GetRunLength() < 0)
        }

        #endregion

        #region Private Members

        private int GetInt32 ( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }
        #endregion        
    }
}
