using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}