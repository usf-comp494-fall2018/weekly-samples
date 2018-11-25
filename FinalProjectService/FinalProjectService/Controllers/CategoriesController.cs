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
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = await _context.Categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }
    }
}