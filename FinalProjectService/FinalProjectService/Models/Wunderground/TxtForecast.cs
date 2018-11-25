using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class TxtForecast
    {
        public string date { get; set; }
        public List<Forecastday> forecastday { get; set; }
    }
}
