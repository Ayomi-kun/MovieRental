using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

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
        
        public ActionResult Details(int id)
        {
            string movies;
            if(id == 1)
            {
                movies = "Lego Movie";
            }
            else if(id == 2)
            {
                movies = "Avengers Endgame";
            }
            else if(id == 3)
            {
                movies = "Titanic";
            }
            else if(id == 4)
            {
                movies = "Iron man";
            }
            else
            {
               return HttpNotFound();
            }
            return Content(movies);
        }
        //movies/edit?id
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
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