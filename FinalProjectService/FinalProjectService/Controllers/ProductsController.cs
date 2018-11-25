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
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}