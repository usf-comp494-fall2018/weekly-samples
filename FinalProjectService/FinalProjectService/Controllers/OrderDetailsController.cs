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
    public class OrderDetailsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public OrderDetailsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }
    }
}