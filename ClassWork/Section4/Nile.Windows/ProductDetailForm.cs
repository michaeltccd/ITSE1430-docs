using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class ProductDetailForm : Form
    {
        #region Construction

        public ProductDetailForm ()
        {
            InitializeComponent();            
        }
        
        public ProductDetailForm ( string title ) : this()
        {
            Text = title;
        }
        #endregion

        /// <summary>Gets or sets the product being shown.</summary>
        public Product Product { get; set; }
        
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkDiscontinued.Checked = Product.IsDiscontinued;
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
            {
                return;
            };

            //Create a new product
            var product = new Product() {
                Id = Product?.Id ?? 0,
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Price = GetPrice(_txtPrice),
                IsDiscontinued = _chkDiscontinued.Checked,
            };
            
            //Validate
            if (!ObjectValidator.TryValidate(product, out var errors))                
            {
                //Show the error
                ShowError("Not valid", "Validation Error");
                return;
            };

            Product = product;
            DialogResult = DialogResult.OK;
            Close();
        }        

        private void OnValidatingName( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            if (String.IsNullOrEmpty(tb.Text))
                _errors.SetError(tb, "Name is required");
            else
                _errors.SetError(tb, "");
        }

        private void OnValidatingPrice( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (GetPrice(tb) < 0)
            {
                e.Cancel = true;
                _errors.SetError(_txtPrice, "Price must be >= 0.");
            } else
                _errors.SetError(_txtPrice, "");
        }
        #endregion

        #region Private Members

        private decimal GetPrice( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out decimal price))
                return price;
                    
            return -1;
        }

        private void ShowError( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
