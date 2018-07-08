using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Data;
using Nile.Data.Sql;
using Nile.Web.Mvc.Models;

namespace Nile.Web.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["NileDatabase"];
            _database = new SqlProductDatabase(connString.ConnectionString);
        }
        private readonly IProductDatabase _database;

        [HttpGet]        
        public ActionResult Index()
        {            
            var products = _database.GetAll();

            return View(products.Select(p => p.ToModel()));
        }        

        [HttpGet]
        public ActionResult Create ()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public ActionResult Create ( ProductModel model )
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToDomain();

                    product = _database.Add(product);

                    return RedirectToAction(nameof(Index));
                };
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product.ToModel());
        }

        [HttpPost]
        public ActionResult Edit( ProductModel model )
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToDomain();

                    product = _database.Update(product);

                    return RedirectToAction("Index");
                };
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        [Route("products/delete/{id}")]
        public ActionResult Delete( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product.ToModel());
        }

        [HttpPost]
        public ActionResult Delete ( ProductModel model )
        {
            try
            {
                var product = _database.GetAll()
                                        .FirstOrDefault(p => p.Id == model.Id);
                if (product == null)
                    return HttpNotFound();

                _database.Remove(model.Id);

                return RedirectToAction(nameof(Index));
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }
    }
}