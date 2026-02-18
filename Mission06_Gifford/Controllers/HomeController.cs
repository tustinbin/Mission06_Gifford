using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Gifford.Models;

namespace Mission06_Gifford.Controllers
{
    public class HomeController : Controller
    {
        private InputFormContext _context;
        public HomeController(InputFormContext temp) {
            //Constructor or liason!
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InputFilmCollection() {
            return View();
        }

        [HttpPost] //saves the changes and moves to confirmation page
        public IActionResult InputFilmCollection(InputForm response) {
            _context.Movies.Add(response);
            _context.SaveChanges();
            
            return View("Confirmation", response);
        }
    }
}
