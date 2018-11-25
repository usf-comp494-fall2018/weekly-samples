using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class Forecastday
    {
        public int period { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string title { get; set; }
        public string fcttext { get; set; }
        public string fcttext_metric { get; set; }
        public string pop { get; set; }
    }
}
