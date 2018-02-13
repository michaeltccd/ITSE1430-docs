/*
 * ITSE 1430
 * Classwork
 */
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //PlayingWithProductMembers();
        }

        //Just a method to play around with members of our Product class
        private void PlayingWithProductMembers ()
        { 
            //Create a new product
            var product = new Product();

            //Cannot use properties as out parameters
            Decimal.TryParse("123", out var price);
            product.Price = price;

            //Get the property Name, no need for a function
            var name = product.Name;
            //var name = product.GetName();

            //Set the property Name, Price and IsDiscontinued
            product.Name = "Product A";
            product.Price = 50;
            product.IsDiscontinued = true;

            //ActualPrice is calculated so you cannot set it
            //product.ActualPrice = 10;
            var price2 = product.ActualPrice;                
            
            //product.SetName("Product A");
            //product.Description = "None";

            //Validate the product
            var error = product.Validate();

            //Convert anything to a string
            var str = product.ToString();

            //Create another product
            var productB = new Product();
            //productB.Name = "Product B";
            //productB.SetName("Product B");
            //productB.Description = product.Description;            

            //Validate the new product
            error = productB.Validate();
        }
    }
}
