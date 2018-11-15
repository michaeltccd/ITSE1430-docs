using System;
using System.ComponentModel.DataAnnotations;
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

            ValidateChildren();
        }

        #region Event Handlers

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            //var movie = new Movie();                        
            //movie.Name = _txtName.Text;
            //movie.Description = _txtDescription.Text;            
            //movie.ReleaseYear = GetInt32(_txtReleaseYear);            
            //movie.RunLength = GetInt32(_txtRunLength);            
            //movie.IsOwned = _chkOwned.Checked;

            //Initializer syntax
            var movie = new Movie() {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                ReleaseYear = GetInt32(_txtReleaseYear),
                RunLength = GetInt32(_txtRunLength),
                IsOwned = _chkOwned.Checked,
            };

            //Validate the movie
            //Validator.TryValidateObject()
            var results = ObjectValidator.TryValidate(movie);
            foreach (var result in results)
            //if (results.Count > 0)
            {
                //var firstMessage = results[0];                
                MessageBox.Show(this, result.ErrorMessage, "Validation Failed",
                                MessageBoxButtons.OK);
                return;
            };

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnValidateName( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //control.Error
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidatingReleaseYear( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1900)
            {
                _errors.SetError(control, "Must be > 1900");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidatingRunLength( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0)
            {
                _errors.SetError(control, "Must be > 0");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        #endregion

        #region Private Members

        private int GetInt32( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }
        #endregion        
    }
}
