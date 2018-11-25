using System;
using System.Collections.Generic;

namespace FinalProjectService.Models
{
    public partial class ThreeDayForecast
    {
        public long Id { get; set; }
        public long Period { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Fcttext { get; set; }
        public string Lastcheck { get; set; }
    }
}
