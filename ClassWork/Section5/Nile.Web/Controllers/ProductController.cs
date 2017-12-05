using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Stores.Sql;
using Nile.Web.Models;

namespace Nile.Web.Controllers
{    
    [DescriptionAttribute("Handles Product requests")]    
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
        
        [HttpPost]
        //[HttpPostAttribute()]
        //[HttpPost()]
        public ActionResult Add ( ProductViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Add(model.ToDomain());

                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        public ActionResult Delete ( int id )
        {
            var product = _database.Get(id);
            if (product == null)
                return HttpNotFound();

            return View(product.ToModel());
        }

        [HttpPost]
        //[HttpPostAttribute()]
        //[HttpPost()]
        public ActionResult Delete ( ProductViewModel model )
        {
            try
            {
                _database.Remove(model.Id);

                return RedirectToAction("List");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };            

            return View(model);
        }

        public ActionResult Edit ( int id )
        {
            var product = _database.Get(id);
            if (product == null)
                return HttpNotFound();

            var value = product.CalculatedProperty;

            return View(product.ToModel());
        }

        [HttpPost]
        //[HttpPostAttribute()]
        //[HttpPost()]
        public ActionResult Edit ( ProductViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.ToDomain());

                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
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