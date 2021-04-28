using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpetStoreASPNET.Helpers;
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
            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products") == null)
            {
                List<Product> products = db.Products.ToList();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products);
            }

            var prices = db.SizesAndPrices.ToList();
            ViewBag.MaxPrice = prices.Max(t => t.Price);
            ViewBag.MinPrice = prices.Min(t => t.Price);

            ViewBag.products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            ViewBag.prices = prices.OrderBy(t => t.Size);
            return View();
        }

        [HttpGet]
        [Route("filter/color/{color}")]
        public IActionResult Filter(string color)
        {
            string ruColor = "";
            switch(color)
            {
                case "red":
                    {
                        ruColor = "Красный";
                        break;
                    }
                case "orange":
                    {
                        ruColor = "Оранжевый";
                        break;
                    }
                case "yellow":
                    {
                        ruColor = "Желтый";
                        break;
                    }
                case "green":
                    {
                        ruColor = "Зеленый";
                        break;
                    }
                case "cyan":
                    {
                        ruColor = "Голубой";
                        break;
                    }
                case "blue":
                    {
                        ruColor = "Синий";
                        break;
                    }
                case "purple":
                    {
                        ruColor = "Фиолетовый";
                        break;
                    }
                case "black":
                    {
                        ruColor = "Черный";
                        break;
                    }
                case "grey":
                    {
                        ruColor = "Серый";
                        break;
                    }
                case "white":
                    {
                        ruColor = "Белый";
                        break;
                    }
            }
            List<Product> products, newSet;
            if (isSetFull()) products = new List<Product>();
            else products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");

            var allProducts = db.Products.ToList();

            if (products.Any(p => p.PrimaryColor.Contains(ruColor)))
            {
                newSet = products.Where(p => !p.PrimaryColor.Contains(ruColor)).ToList();
                if (newSet.Count == 0) newSet = allProducts;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", newSet);
            }
            else
            {
                newSet = allProducts.Where(p => p.PrimaryColor.Contains(ruColor)).ToList();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products.Union(newSet));
            }
            return RedirectToAction("Index");
        }

        public bool isSetFull()
        {
            var fullSet = db.Products.ToList();
            var sessionSet = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            if (fullSet.Count == sessionSet.Count) return true;
            return false;
        }
    }
}
