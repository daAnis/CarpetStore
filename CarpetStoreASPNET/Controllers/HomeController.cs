using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpetStoreASPNET.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /<controller>/
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            ViewBag.prices = db.SizesAndPrices.ToList();
            return View();
        }
    }
}
