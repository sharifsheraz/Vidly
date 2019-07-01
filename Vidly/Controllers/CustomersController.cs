using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
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
            //var customers = _context.Customers.Include(c=> c.MembershipType ).ToList();
            //return View(customers);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(/*[Bind(Exclude="Id")]*/Customer customer)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            else
            {
                if (customer.Id == 0)
                   _context.Customers.Add(customer);
                else
                {
                    var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                    //  TryUpdateModel(customerinDb);
                    customerinDb.Name = customer.Name;
                    customerinDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customerinDb.MemberShipTypeID = customer.MemberShipTypeID;
                    

                }
                _context.SaveChanges();
                return RedirectToAction("Index","Customers");
            }
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",ViewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}