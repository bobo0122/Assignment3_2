using Assignment3_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_2.Controllers
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

        public IActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();

        }

        [HttpPost]
        public IActionResult EnterMovie(ApplicationResponse appResponse)
        //this is just going to take you to the DatingApplication.cshtml
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(appResponse);
                return View("Confirmation",appResponse);
            }
            else
            {
                return View();
            }
           
        }


        public IActionResult MoviesList()
        {
           return View(TempStorage.Applications.Where(r => r.Title != "Independence Day"));
            
        }
        public IActionResult Confirmation()
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
