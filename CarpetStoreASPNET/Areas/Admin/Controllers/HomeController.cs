using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpetStoreASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            ViewBag.prices = db.SizesAndPrices.ToList();
            return View();
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(Product product, IFormFile[] photos)
        {
            if (photos == null || photos.Length == 0)
            {
                return Content("File(s) not selected");
            }
            else
            {
                product.Photos = new List<string>();
                foreach (IFormFile photo in photos)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    product.Photos.Add(photo.FileName);
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [Route("addPrice")]
        [HttpGet]
        public IActionResult AddSizePrice()
        {
            return View();
        }

        [Route("addPrice")]
        [HttpPost]
        public IActionResult AddSizePrice(SizeAndPrice sizeAndPrice)
        {
            db.SizesAndPrices.Add(sizeAndPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
