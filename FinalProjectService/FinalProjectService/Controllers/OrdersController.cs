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
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public OrdersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}