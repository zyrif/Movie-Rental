using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModels;

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {

            var viewmodel = new MovieListViewModel()
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(viewmodel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(new MovieDetailsViewModel
            {
                Movie = movie
            });
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Add()
        {
            return View("Form", new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            });
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View("Form", new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            });
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Movie.Id == 0)
                _context.Movies.Add(viewModel.Movie);
            else
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).Single(m => m.Id == viewModel.Movie.Id);
                movieInDb.Id = viewModel.Movie.Id;
                movieInDb.Name = viewModel.Movie.Name;
                movieInDb.GenreId = viewModel.Movie.GenreId;
                movieInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDb.DateAdded = viewModel.Movie.DateAdded;
                movieInDb.NumberInStock = viewModel.Movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}