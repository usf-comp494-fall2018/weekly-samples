using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class WundergroundForecast
    {
        public Response response { get; set; }
        public Forecast forecast { get; set; }
    }
}
