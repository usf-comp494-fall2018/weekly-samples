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
    public class SuppliersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public SuppliersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public IEnumerable<Suppliers> GetSuppliers()
        {
            return _context.Suppliers;
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuppliers([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var suppliers = await _context.Suppliers.FindAsync(id);

            if (suppliers == null)
            {
                return NotFound();
            }

            return Ok(suppliers);
        }
    }
}