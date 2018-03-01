/*
 * ITSE 1430
 * Classwork
 */
using System;
using System.Windows.Forms;
using Nile.Data.Memory;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            RefreshUI();
        }

        #region Event Handlers

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd ( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new ProductDetailForm("Add Product");

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Add to database
            _database.Add(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);
            
            //Find empty array element
            //var index = FindEmptyProductIndex();
            //if (index >= 0)
            //_products[index] = form.Product;                    
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            //Get the first product
            var products = _database.GetAll();
            var product = (products.Length > 0) ? products[0] : null;
            if (product == null)
                return;

            //var index = FindEmptyProductIndex() - 1;
            //if (index < 0)
            //    return;                        
            //if (_product == null)
            //    return;

            var form = new ProductDetailForm(product);            
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Update the product
            _database.Edit(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);
        }

        private void OnProductRemove( object sender, EventArgs e )
        {
            //var index = FindEmptyProductIndex() - 1;
            //if (index < 0)
            //  return;

            //Get the first product
            var products = _database.GetAll();
            var product = (products.Length > 0) ? products[0] : null;
            if (product == null)
                return;

            if (!ShowConfirmation("Are you sure?", "Remove Product"))                             
                return;

            //Remove product
            _database.Remove(product.Id);
            //_products[index] = null;
        }        
        
        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        private void RefreshUI ()
        {
            //Get products
            var products = _database.GetAll();
            
            //Bind to grid
            dataGridView1.DataSource = products;
        }

        private bool ShowConfirmation ( string message, string title )
        {
            return MessageBox.Show(this, message, title
                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                           == DialogResult.Yes;
        }

        private MemoryProductDatabase _database = new MemoryProductDatabase();
    }
}
