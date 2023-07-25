/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using Microsoft.AspNetCore.Mvc;

using MovieLibrary.WebHost.Models;

namespace MovieLibrary.WebHost.Controllers;

[Route("/movie")]
public class MovieController : Controller
{
    public MovieController ( IMovieDatabase database )
    {
        _database = database;
    }

    //GET /movie/index or /movie
    [HttpGet]
    public IActionResult Index ()
    {
        var model = _database.GetAll()
                             .OrderBy(x => x.Title)
                             .Select(x => new MovieViewModel(x));

        return View("Index", model);
    }

    //GET /movie/view/{id}
    [HttpGet("view/{id}")]
    public IActionResult Details ( int id )
    {
        var movie = _database.Get(id);
        if (movie == null)
            return NotFound(); // 404

        return View(new MovieViewModel(movie));
    }

    [HttpGet("create")]
    public IActionResult Create ()
    {
        return View(new MovieViewModel());
    }

    // PRG - Post, Redirect, Get
    [HttpPost("create")]
    public IActionResult Create ( MovieViewModel model )
    {
        //Validate
        if (ModelState.IsValid)
        {
            var movie = model.ToMovie();

            try
            {
                movie = _database.Add(movie);

                //Send to details page
                return RedirectToAction("Details", new { id = movie.Id });
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };
        };

        return View(model);
    }

    [HttpGet("delete")]
    public IActionResult Delete ( int id )
    {
        var movie = _database.Get(id);
        if (movie == null)
            return NotFound();

        return View(new MovieViewModel(movie));
    }

    [HttpPost("delete")]
    public IActionResult Delete ( MovieViewModel model )
    {
        try
        {
            _database.Delete(model.Id);

            return RedirectToAction("Index");
        } catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        };

        return View(model);
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit ( int id )
    {
        var movie = _database.Get(id);
        if (movie == null)
            return NotFound();

        return View(new MovieViewModel(movie));
    }

    [HttpPost("Edit")]
    public IActionResult Edit ( MovieViewModel model )
    {
        //Validate
        if (ModelState.IsValid)
        {
            var movie = model.ToMovie();

            try
            {
                _database.Update(movie.Id, movie);

                //Send to details page
                return RedirectToAction("Details", new { id = movie.Id });
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };
        };

        return View(model);
    }

    private readonly IMovieDatabase _database;
}
