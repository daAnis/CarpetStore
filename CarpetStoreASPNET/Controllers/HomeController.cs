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
            List<Product> products;
            
            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products") == null)
            {
                products = db.Products.ToList();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products);
            }

            products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");

            var prices = db.SizesAndPrices.ToList();
            var pricesInRange = prices.Where(p => products.Any(c => c.Id == p.ProductId)).ToList();

            if (prices.Count > 0)
            {
                ViewBag.MaxPrice = prices.Max(t => t.Price);
                ViewBag.MinPrice = prices.Min(t => t.Price);
            }
            else
            {
                ViewBag.MaxPrice = 0;
                ViewBag.MinPrice = 0;
            }

            if (pricesInRange.Count > 0)
            {
                ViewBag.MaxPriceNow = pricesInRange.Max(t => t.Price);
                ViewBag.MinPriceNow = pricesInRange.Min(t => t.Price);
            }
            else
            {
                ViewBag.MaxPriceNow = 0;
                ViewBag.MinPriceNow = 0;
            }

            ViewBag.products = products;
            ViewBag.prices = prices.OrderBy(t => t.Size);
            return View();
        }

        [HttpGet]
        [Route("filter/price")]
        public IActionResult FilterByPrice()
        {
            //string data = HttpContext.Request.Query["data"].ToString();
            string data = HttpContext.Request.QueryString.ToString();
            data = data.Replace("?=", "");
            data = data.Replace("%2C", " ");
            string[] filterData = data.Split(new char[] { ' ' });

            decimal min = Convert.ToDecimal(filterData[0]);
            decimal max = Convert.ToDecimal(filterData[1]);

            var allPrices = db.SizesAndPrices.ToList();
            var allProducts = db.Products.ToList();
            var pricesInRange = allPrices.Where(p => p.Price >= min && p.Price <= max).ToList();
            var productsInRange = allProducts.Where(c => pricesInRange.Any(p => p.ProductId == c.Id)).ToList();
            filter(productsInRange);
            //var products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            //var productsInRange = products.Where(c => pricesInRange.Any(p => p.ProductId == c.Id)).ToList();
            //SessionHelper.SetObjectAsJson(HttpContext.Session, "products", productsInRange);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("filter/size/{size}")]
        public IActionResult FilterBySize(string size)
        {
            string sizeM = size.Replace("%20", " ");

            List<Product> products, newSet;
            List<SizeAndPrice> containedSizes;
            var allProducts = db.Products.ToList();
            var allSizes = db.SizesAndPrices.ToList();
            if (isSetContainAllColors())
            {
                products = new List<Product>();
                containedSizes = allSizes;
            }
            else
            {
                products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
                containedSizes = allSizes.Where(s => products.Any(p => s.ProductId == p.Id)).ToList();
            }

            if (containedSizes.Any(s => s.Size.Contains(sizeM)))
            {
                newSet = allProducts.Where(p => containedSizes.Any(s => !s.Size.Contains(sizeM) && s.ProductId == p.Id)).ToList();
                if (newSet.Count == 0) newSet = allProducts;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", newSet);
            }
            else
            {
                newSet = allProducts.Where(p => allSizes.Any(s => s.Size.Contains(sizeM) && s.ProductId == p.Id)).ToList();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products.Union(newSet));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("filter/color/{color}")]
        public IActionResult FilterByColor(string color)
        {
            string ruColor = getRuColor(color);
            var allProducts = db.Products.ToList();
            var newSet = allProducts.Where(p => p.PrimaryColor.Contains(ruColor)).ToList();
            filter(newSet);

            /*List<Product> products, newSet;

            if (isSetContainAllSizes()) products = new List<Product>();
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
            }*/
            return RedirectToAction("Index");
        }

        public string getRuColor(string color)
        {
            switch (color)
            {
                case "red":
                    {
                        return "Красный";
                    }
                case "orange":
                    {
                        return "Оранжевый";
                    }
                case "yellow":
                    {
                        return "Желтый";
                    }
                case "green":
                    {
                        return "Зеленый";
                    }
                case "cyan":
                    {
                        return "Голубой";
                    }
                case "blue":
                    {
                        return "Синий";
                    }
                case "purple":
                    {
                        return "Фиолетовый";
                    }
                case "black":
                    {
                        return "Черный";
                    }
                case "grey":
                    {
                        return "Серый";
                    }
                case "white":
                    {
                        return "Белый";
                    }
                default: return color;
            }
        }

        public bool isSetFull()
        {
            var fullSet = db.Products.ToList();
            var sessionSet = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            if (fullSet.Count == sessionSet.Count) return true;
            return false;
        }

        public bool isSetContainAllColors()
        {
            var fullSet = db.Products.ToList();
            var sessionSet = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");

            var colorSet = fullSet.Where(f => sessionSet.Any(s => s.PrimaryColor.Contains(f.PrimaryColor))).ToList();
            if (colorSet.Count == fullSet.Count) return true;
            return false;
        }

        public bool isSetContainAllSizes()
        {
            var fullSet = db.Products.ToList();
            var sessionSet = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            var allSizes = db.SizesAndPrices.ToList();

            var sizeSetForAll = allSizes.Where(s => fullSet.Any(p => p.Id == s.ProductId)).ToList();
            var sizeSetForSession = allSizes.Where(s => sessionSet.Any(p => p.Id == s.ProductId)).ToList();
            if (sizeSetForAll.Count == sizeSetForSession.Count) return true;
            return false;
        }

        public void filter(List<Product> products)
        {
            var sessionSet = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "products");
            var filteredSet = sessionSet.Intersect(products, new ProductComparer()).ToList();
            if (filteredSet.Count == 0)
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", db.Products.ToList());
            else
                SessionHelper.SetObjectAsJson(HttpContext.Session, "products", filteredSet);
        }
    }
}
