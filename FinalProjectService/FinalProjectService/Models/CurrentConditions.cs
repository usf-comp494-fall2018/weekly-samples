using System;
using System.Collections.Generic;

namespace FinalProjectService.Models
{
    public partial class CurrentConditions
    {
        public long Id { get; set; }
        public string ObservationTime { get; set; }
        public string Weather { get; set; }
        public double TempF { get; set; }
        public string RelativeHumidity { get; set; }
        public string WindDir { get; set; }
        public double WindMph { get; set; }
        public string Lastcheck { get; set; }
    }
}
