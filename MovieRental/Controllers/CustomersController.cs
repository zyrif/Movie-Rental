using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Management;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModels;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(new CustomerListViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            });
        }

        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(new CustomerDetailsViewModel
            {
                Customer = customer
            });
        }

        public ActionResult Add()
        {
            return View("AddorEdit", new NewCustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            });

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View("AddorEdit", new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            });
        }


        [HttpPost]
        public ActionResult Save(NewCustomerViewModel viewModel)
        { 
            if(viewModel.Customer.Id == 0)
                _context.Customers.Add(viewModel.Customer);
            else
            {
                var customerInDb = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.Id = viewModel.Customer.Id;
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.Birthdate = viewModel.Customer.Birthdate;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = viewModel.Customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


    }
}