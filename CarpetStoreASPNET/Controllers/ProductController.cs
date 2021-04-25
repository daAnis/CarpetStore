using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpetStoreASPNET.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Controllers
{
    [Route("carpet")]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        //[Route("index")]
        [Route("{id:int}")]
        public IActionResult Index(int id)
        {
            Product product = db.Products.Find(id);
            var sizesAndPrices = db.SizesAndPrices.Where(p => p.ProductId == id).ToList();
            ViewBag.product = product;
            ViewBag.sizesAndPrices = sizesAndPrices;
            return View();
        }
    }
}
