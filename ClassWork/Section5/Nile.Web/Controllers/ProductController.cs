using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Web.Models;

namespace Nile.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var model = new List<ProductViewModel>() {
                new ProductViewModel() { Id = 1, Name = "Product A", Price = 123 }
            };
            return View(model);
        }
    }
}