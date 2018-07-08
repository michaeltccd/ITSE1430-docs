using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nile.Data;
using Nile.Data.Sql;
using Nile.Web.Mvc.Models;

namespace Nile.Web.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController ()
        {
            //var connString = ConfigurationManager.ConnectionStrings["NileDatabase"];
            var connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=NileDatabase;Integrated Security=True;";
            _database = new SqlProductDatabase(connString);
        }
        private readonly IProductDatabase _database;

        [HttpGet]        
        public IActionResult Index()
        {            
            var products = _database.GetAll();

            return View(products.Select(p => p.ToModel()));
        }        

        [HttpGet]
        public IActionResult Create ()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult Create ( ProductModel model )
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
        public IActionResult Edit ( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product.ToModel());
        }

        [HttpPost]
        public IActionResult Edit( ProductModel model )
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
        public IActionResult Delete( int id )
        {
            var product = _database.GetAll()
                                    .FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product.ToModel());
        }

        [HttpPost]
        public IActionResult Delete ( ProductModel model )
        {
            try
            {
                var product = _database.GetAll()
                                        .FirstOrDefault(p => p.Id == model.Id);
                if (product == null)
                    return NotFound();

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