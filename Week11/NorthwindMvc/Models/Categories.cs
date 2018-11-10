﻿using System;
using System.Collections.Generic;

namespace NorthwindMvc.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
