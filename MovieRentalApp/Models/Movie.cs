using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please Enter the Name of the Movie")]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreID { get; set; }

        [Display(Name ="Released Date")]
        [Required]
        public DateTime ReleasedDate { get; set; }
        
        
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        
               
    }
}