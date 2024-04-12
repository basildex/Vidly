using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            // Query data using Entity Framework Core
            var customers = _context.Customers.ToList();

            return customers;
        }
    }
}
