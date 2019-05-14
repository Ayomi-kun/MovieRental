using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Tobi Dahunsi"},
                new Customer {Name ="Olamide Jegede"},
                new Customer {Name = "Niyi Obikoya"}
            };
            var ViewModel = new RandomMovieViewModel
            {
                Customers = customers
            };


            return View(ViewModel);
            
        }
        public ActionResult Details(int id)
        {
            string customer;
            if (id == 1)
            {
                customer = "Tobi Dahunsi";
            }
            else if (id == 2)
            {
                customer = "Olamide Jegede";
            }
            else if (id == 3)
            {
                customer = "Niyi Obikoya";
            }
            else
            {
                customer = "";
            }
            return Content(customer);
        }

    }
}