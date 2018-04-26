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

            return Json(products.Select(p => p.ToModel()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details ( int id )
        {
            var product = _database.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return Json(product.ToModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return Json(new ProductModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create ( ProductModel model )
        {
            if (!ModelState.IsValid)
                throw new Exception("Model not valid");

            try
            {
                var product = model.ToDomain();

                product = _database.Add(product);

                return Json(product.ToModel(), JsonRequestBehavior.AllowGet);
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return Json(ModelState, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return Json(product.ToModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit( ProductModel model )
        {
            if (!ModelState.IsValid)
                throw new Exception("Model not valid");

            try
            {
                var product = model.ToDomain();

                product = _database.Update(product);

                return Json(product.ToModel(), JsonRequestBehavior.AllowGet);
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return Json(ModelState, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("products/delete/{id}")]
        public ActionResult GetDelete( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return Json(product.ToModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete ( int id )
        {
            try
            {
                var product = _database.GetAll()
                                        .FirstOrDefault(p => p.Id == id);
                if (product == null)
                    return HttpNotFound();

                _database.Remove(id);

                return Content("");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return Json(ModelState, JsonRequestBehavior.AllowGet);
        }
    }
}