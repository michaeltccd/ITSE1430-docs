using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Itse1430.MovieLib;
using Itse1430.MovieLib.Sql;
using Movie.Mvc.Models;

namespace Movie.Mvc.Controllers
{
    public class MovieController : Controller
    {
        public MovieController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];

            _database = new SqlMovieDatabase(connString.ConnectionString);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var items = _database.GetAll();

            return View(items.Select(i => new MovieModel(i)));
            //return View("Index");
        }

        [HttpGet]
        public ActionResult Create ()
        {
            var model = new MovieModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var item = _database.GetAll().FirstOrDefault(i => i.Id == id);

            return View(new MovieModel(item));
        }

        [HttpPost]
        public ActionResult Edit( MovieModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();

                    var existing = _database.GetAll()
                                        .FirstOrDefault(i => i.Id == model.Id);
                    _database.Edit(existing.Name, item);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create ( MovieModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();

                    _database.Add(item);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete ( int id )
        {
            var item = _database.GetAll().FirstOrDefault(i => i.Id == id);

            return View(new MovieModel(item));
        }

        [HttpPost]
        public ActionResult Delete ( MovieModel model )
        {
            try
            {
                var existing = _database.GetAll().FirstOrDefault(i => i.Id == model.Id);
                if (existing == null)
                    return HttpNotFound();

                _database.Remove(existing.Name);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            };
        }

        private readonly IMovieDatabase _database;
    }
}