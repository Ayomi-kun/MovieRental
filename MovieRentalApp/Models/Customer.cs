using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required (ErrorMessage= " Please enter the Customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Memebership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeID { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }
    }
}