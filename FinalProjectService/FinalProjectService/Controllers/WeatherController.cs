using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public WeatherController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Weather
        [HttpGet (Name = "GetThreeDayForecast")]
        public IEnumerable<ThreeDayForecast> GetThreeDayForecast()
        {
            var weather = new WeatherModel(_context);
            return weather.GetThreeDayForecast();
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "GetCurrentConditions")]
        public CurrentConditions GetCurrentConditions(int id)
        {
            // Id is irrelevant here, just used to separate get conditions and get forecast
            var weather = new WeatherModel(_context);
            return weather.GetCurrentConditions();
        }
    }
}
