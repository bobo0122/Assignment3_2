using Assignment3_2.Models;
using Assignment3_2.Models.ViewModels;
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
        private MovieDbContext _context { get; set; }        //Sets up variable to be used in the home controller class

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
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
                _context.ApplicationResponses.Add(appResponse);//Adds new group to the list
               _context.SaveChanges();//Saves changes to the DB
                return View("Confirmation");//Redirect to the confirmation page if successful
            }
            else
            {
                return View();
            }
        }

        public IActionResult MoviesList()
        {
           return View(new MovieViewModel
           {
               ApplicationResponses = _context.ApplicationResponses
           });
        }

        //update page 
        public IActionResult Update(string moviename)
        {

            ApplicationResponse appResponse = _context.ApplicationResponses
                .Where(y => y.Title == moviename).FirstOrDefault();
            _context.SaveChanges();
            return View(appResponse);
                
        }

        //update done and redirect
        [HttpPost]
        public IActionResult Update(ApplicationResponse appResponse, string moviename)
        {
           _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Category = appResponse.Category;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Title  = appResponse.Title;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Year = appResponse.Year;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Director = appResponse.Director;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().SelectRatingType = appResponse.SelectRatingType;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Edited = appResponse.Edited;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().LentTo = appResponse.LentTo;
            _context.ApplicationResponses.Where(y => y.Title == moviename).FirstOrDefault().Notes = appResponse.Notes;
            _context.SaveChanges();
            return RedirectToAction("MoviesList");
        }

        [HttpPost]
        public IActionResult Delete(string moviename)
        {
            ApplicationResponse appResponse = _context.ApplicationResponses.Where(y => y.Title == moviename ).FirstOrDefault();
            _context.ApplicationResponses.Remove(appResponse);
            _context.SaveChanges();
            return RedirectToAction("MoviesList");
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
