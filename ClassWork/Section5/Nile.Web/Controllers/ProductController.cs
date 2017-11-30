using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Stores.Sql;
using Nile.Web.Models;

namespace Nile.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController ( ) : this(GetDatabase())
        {
        }

        public ProductController ( IProductDatabase database )
        {
            _database = database;
        }

        public ActionResult Add ()
        {
            var model = new ProductViewModel();

            return View(model);
        }

        //public ActionResult Add ( ProductViewModel model )
        //{

        //}

        public ActionResult Delete ( int id )
        {
            var product = _database.Get(id);

            return View(product.ToModel());
        }

        public ActionResult Edit ( int id )
        {
            var product = _database.Get(id);
            
            return View(product.ToModel());
        }

        // GET: Product
        public ActionResult List()
        {
            var products = _database.GetAll();

            return View(products.ToModel());
        }

        private static IProductDatabase GetDatabase ()
        {
            var connstring = ConfigurationManager.ConnectionStrings["ProductDatabase"];

            return new SqlProductDatabase(connstring.ConnectionString);
        }
        private readonly IProductDatabase _database;
    }
}