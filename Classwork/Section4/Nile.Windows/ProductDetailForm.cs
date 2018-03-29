using System;
using System.Linq;
using System.Windows.Forms;

namespace Nile.Windows
{
    /// <summary>Provides a form for adding/editing <see cref="Product"/>.</summary>
    public partial class ProductDetailForm : Form
    {
        #region Construction

        public ProductDetailForm()
        {
            InitializeComponent();
        }

        public ProductDetailForm( string title ) : this()
        {
            Text = title;
        }

        public ProductDetailForm( Product product ) :this("Edit Product")
        {
            Product = product;
        }
        #endregion

        /// <summary>Gets or sets the product being edited.</summary>
        public Product Product { get; set; }
        
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Load product
            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkIsDiscontinued.Checked = Product.IsDiscontinued;
            };

            ValidateChildren();
        }

        #region Event Handlers

        private void OnCancel( object sender, EventArgs e )
        {
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Force validation of child controls
            if (!ValidateChildren())
                return;

            // Create product - using object initializer syntax
            var product = new Product() {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Price = ConvertToPrice(_txtPrice),
                IsDiscontinued = _chkIsDiscontinued.Checked,
            };

            //Validate product using IValidatableObject
            var errors = ObjectValidator.TryValidate(product);
            if (errors.Count() > 0)
            {
                //Get first error
                DisplayError(errors.ElementAt(0).ErrorMessage);
                return;
            };            
            
            //Return from form
            Product = product;
            DialogResult = DialogResult.OK;

            Close();
        }
        #endregion
        
        private void DisplayError ( string message )
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        private decimal ConvertToPrice ( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            return -1;
        }

        private void _txtName_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            if (String.IsNullOrEmpty(textbox.Text))
            {

                _errorProvider.SetError(textbox, "Name is required");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }

        private void _txtPrice_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            var price = ConvertToPrice(textbox);
            if (price < 0)
            {
                _errorProvider.SetError(textbox, "Price must be >= 0");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }
    }
}
