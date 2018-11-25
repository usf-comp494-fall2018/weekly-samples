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
    public class ShippersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ShippersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Shippers
        [HttpGet]
        public IEnumerable<Shippers> GetShippers()
        {
            return _context.Shippers;
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippers([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shippers = await _context.Shippers.FindAsync(id);

            if (shippers == null)
            {
                return NotFound();
            }

            return Ok(shippers);
        }
    }
}