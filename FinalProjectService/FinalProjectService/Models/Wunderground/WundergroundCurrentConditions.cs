using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class WundergroundCurrentConditions
    {
        public Response response { get; set; }
        public CurrentObservation current_observation { get; set; }
    }
}
