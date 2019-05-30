using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalApp.Models;
namespace MovieRentalApp.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}