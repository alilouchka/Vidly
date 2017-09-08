using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Dispose is called when we finish using Context 
        //The Dispose method leaves the Context in an unusable state. After calling Dispose,
        //you must release all references to the Context so the garbage collector can reclaim the memory that the Context was occupying. 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {

            return View();
        }
        public ViewResult Index()
        {
            // var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();   // this instruction will not query the db , we neet to use an iterator in the ViewPage or to use toList() method 
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}