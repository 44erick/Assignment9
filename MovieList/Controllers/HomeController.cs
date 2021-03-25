using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieListDBContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieListDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult movieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult movieForm(modelResponse appResponse)
        {
            if (appResponse.Title == "Independence Day")
            {
                //if it's independence day don't show up
                return View();
            }
            //checks to see if user inputted required material
            else if (ModelState.IsValid)
            {
                //if valid then redirect them to confirmation page
                _context.modelResponses.Add(appResponse);
                _context.SaveChanges();
                return View("confirmation", appResponse);
            }

            else
            {
                //if not valid then show errors
                return View();
            }
        }

        //edit movie 
        [HttpPost]
        public IActionResult EditMoviefirst(int movieID)
        {
            //make object where movieId matches with what was passed
            modelResponse responseMovie = _context.modelResponses.Where(x => x.MovieID == movieID).FirstOrDefault();


            ViewBag.modelResponse = responseMovie;

            //returns EditMovie page and passes necessary ViewBag to be used in second part
            return View("EditMovie", ViewBag.modelResponse);
        }


        [HttpPost]
        public IActionResult EditMovietwo(modelResponse responseMovie)
        {
            //If everything is valid then update modelResponse and save changes.
            if (ModelState.IsValid)
            {
                TempData["Title"] = responseMovie.Title;

                _context.modelResponses.Update(responseMovie);
                _context.SaveChanges();

                return View("ConfirmEdit");
            }

            else
            {
                ViewBag.modelReponse = responseMovie;

                return View("EditMovie", ViewBag.modelResponse);
            }
        }


        //return movie list
        public IActionResult movieList()
        {
            return View(_context.modelResponses);
        }


        //delete movie same way we edit
        [HttpPost]
        public IActionResult DeleteMovie(int movieID)
        {
            modelResponse responseMovie = _context.modelResponses.Where(x => x.MovieID == movieID).FirstOrDefault();

            TempData["Title"] = responseMovie.Title;

            _context.modelResponses.Remove(responseMovie);
            _context.SaveChanges();
            return View("ConfirmDelete");
        }

        public IActionResult podcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}