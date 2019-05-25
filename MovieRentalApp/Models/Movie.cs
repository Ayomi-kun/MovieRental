using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreID { get; set; }
    }
}