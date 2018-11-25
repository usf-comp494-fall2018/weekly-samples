using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectService.Models;

namespace FinalProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }
}