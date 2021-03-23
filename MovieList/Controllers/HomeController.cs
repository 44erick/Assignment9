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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                tempStorage.AddMovie(appResponse);
                return View("confirmation", appResponse);
            }

            else
            {
                //if not valid then show errors
                return View();
            }
        }

        public IActionResult movieList()
        {
            //temporary storage while session is active
            return View(tempStorage.Moviess);
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