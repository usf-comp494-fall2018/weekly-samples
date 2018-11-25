using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class Forecast
    {
        public TxtForecast txt_forecast { get; set; }
        public Simpleforecast simpleforecast { get; set; }
    }
}
