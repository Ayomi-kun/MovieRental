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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();      
        }

        //dispose this object properly
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers   
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
            //var customers = new List<Customer>
            //{
            //    new Customer {Name = "Tobi Dahunsi"},
            //    new Customer {Name ="Olamide Jegede"},
            //    new Customer {Name = "Niyi Obikoya"}
            //};
            //var ViewModel = new RandomMovieViewModel
            //{
            //    Customers = customers
            //};


            //return View(ViewModel);
            
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CreateFormViewModel {
                MembershipTypes = membershipType
            };
            return View("CustomerForm", viewModel); 
        }
        
        [HttpPost]    
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);

                //use the below method if you want to restrict the updated properties, just list the ones you want to update
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;  
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var ViewModel = new CreateFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }
            
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
            //string customer;
            //if (id == 1)
            //{
            //    customer = "Tobi Dahunsi";
            //}
            //else if (id == 2)
            //{
            //    customer = "Olamide Jegede";
            //}
            //else if (id == 3)
            //{
            //    customer = "Niyi Obikoya";
            //}
            //else
            //{
            //    return HttpNotFound();
            //}
            //return Content(customer);


            // new method

        }

            

    }
}