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

        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            var prices = db.SizesAndPrices.ToList();
            ViewBag.MaxPrice = prices.Max(t => t.Price);
            ViewBag.MinPrice = prices.Min(t => t.Price);

            ViewBag.products = db.Products.ToList();
            ViewBag.prices = prices.OrderBy(t => t.Size);
            return View();
        }
    }
}
