using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Gifford.Models;

namespace Mission06_Gifford.Controllers
{
    public class HomeController : Controller
    {
        private InputFormContext _context;
        public HomeController(InputFormContext temp) {
            //Constructor. THE LIASON
            _context = temp;
        }
        public IActionResult Index() //the include thing is to get category to show up on the site
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet] //this is for making a new record. brings the viewbag in
        public IActionResult InputFilmCollection() {

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View(new InputForm());
        }

        [HttpPost] //posting/saving the new record only if validation passes
        public IActionResult InputFilmCollection(InputForm response) {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

                return View(response);
            }
        }

        [HttpGet] //this is to edit. grabs the record and redirects to the submit view
        public IActionResult Edit(int id) {

            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("InputFilmCollection", recordToEdit);
        }

        [HttpPost] //saves the changes
        public IActionResult Edit(InputForm updatedMovie) {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet] //gets the record to delete and moves on to delete view
        public IActionResult Delete(int id) {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost] //deletes
        public IActionResult Delete(InputForm deletedMovie) {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
