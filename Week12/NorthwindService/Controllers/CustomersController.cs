using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindLibrary;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository repo;

        // Constructor injects registered repository
        public CustomersController(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/customers
        // GET: api/customers/?country=[country]
        [HttpGet]
        public async Task<IEnumerable<Customers>> GetCustomers(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }

        // GET: api/customers/[id]
        [HttpGet ("{id}", Name ="GetCustomer")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customers c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }
            return new ObjectResult(c); // 200 OK
        }

        // POST: api/customers
        // BODY: Customer (JSON, XML)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customers c)
        {
            if(c == null)
            {
                return BadRequest(); // 400 Bad request
            }

            Customers added = await repo.CreateAsync(c);
            return CreatedAtRoute("GetCustomer", // use named route
                new { id = added.CustomerId.ToLower() }, c); // 201 Created
        }

        // PUT: api/customers/[id]
        // BODY: Customer (JSON, XML)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Customers c)
        {
            id = id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            if(c == null || c.CustomerId != id)
            {
                return BadRequest(); // 400 Bad request
            }

            var existing = await repo.RetrieveAsync(id);
            if(existing == null)
            {
                return BadRequest(); // 400 Bad request
            }

            await repo.UpdateAsync(id, c);
            return new NoContentResult(); // 204 No content
        }

        // DELETE: api/customers/[id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await repo.RetrieveAsync(id);
            if(existing == null)
            {
                return NotFound(); // 404 Resource not found
            }

            bool deleted = await repo.DeleteAsync(id);

            if(deleted)
            {
                return new NoContentResult(); // 204 No content
            }
            else
            {
                return BadRequest(); // 400 Bad request
            }
        }
    }
}