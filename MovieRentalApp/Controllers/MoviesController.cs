using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;
using System.Data.Entity.Infrastructure;

namespace MovieRentalApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
            //var movies = new List<Movie>
            //{ new Movie { Name = "Lego Movie" },
            //  new Movie {Name = "Avengers Endgame" },
            //  new Movie {Name = "Titanic" },
            //  new Movie {Name = "Iron Man" }
            //};
            //var ViewModel = new RandomMovieViewModel
            //{
            //    Movie = movies
            //};

            
            //return View(ViewModel);

           

            //return RedirectToAction("Index", "Home", new { page =1, sortBy= "name"});
        }
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new CreateFormViewModel
            {
                Genre = genre
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

                _context.SaveChanges();
            
            //catch (DbUpdateException e)
            //{
            //    Console.WriteLine(e);
            //}
            return RedirectToAction("Index" , "Movies");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
            
            //string movies;
            //if(id == 1)
            //{
            //    movies = "Lego Movie";
            //}
            //else if(id == 2)
            //{
            //    movies = "Avengers Endgame";
            //}
            //else if(id == 3)
            //{
            //    movies = "Titanic";
            //}
            //else if(id == 4)
            //{
            //    movies = "Iron man";
            //}
            //else
            //{
            //   return HttpNotFound();
            //}

        }
        //movies/edit?id
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CreateFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }

        //Movies/page
        public ActionResult page(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //movies/releasedby/year/month
        [Route("movies/releasedby/{year:regex(\\d{4})}/{month:range(1,12)}")] 
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(String.Format("Movie release month and year = {0}/{1}", month,year));
        }
    }
}