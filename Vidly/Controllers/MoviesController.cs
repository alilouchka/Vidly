using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();

            return View(movies);    
        }

        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m=> m.Genre).FirstOrDefault(m => m.Id == id);

            return View(movie);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
                return View("MovieForm", new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres
                });

            
            if(movie.Id ==0)
            _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                
                //Modification des paramètres
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;


            }



            _context.SaveChanges();


            return RedirectToAction("Index","Movies");

        }

        

        public ActionResult MovieForm()
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
               Genres = _context.Genres
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres;

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };

            return View("MovieForm",viewModel);
        }
    }
}