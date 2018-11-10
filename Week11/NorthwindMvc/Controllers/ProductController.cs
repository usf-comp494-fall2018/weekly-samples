using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindMvc.Models;

namespace NorthwindMvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var db = new NorthwindContext();
            return View(db.Products.OrderBy(p => p.ProductName).ToList());
        }

        public IActionResult Details(long id)
        {
            var db = new NorthwindContext();
            var model = db.Products.Find(id);
            return View(model);
        }
    }
}