using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindMvc.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount { get; set; }
        public IList<Categories> Categories { get; set; }
        public IList<Products> Products { get; set; }
    }
}
