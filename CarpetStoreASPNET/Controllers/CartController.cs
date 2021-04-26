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
    [Route("cart")]
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null) return View("Empty");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.SizeAndPrice.Price * item.Quantity);
            ViewBag.products = db.Products.ToList();
            ViewBag.sizesAndPrices = db.SizesAndPrices.ToList();
            return View("Index");
        }

        [Route("discount/{dis}/{total:int}")]
        public ContentResult Discount(string dis, decimal total)
        {
            if (dis.Equals("1234"))
            {
                decimal newTotal = total * 0.2m;
                return Content(newTotal.ToString());
            }
            return Content(total.ToString());
        }

        [Route("buy/{id:int}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = db.Products.Find(db.SizesAndPrices.Find(id).ProductId), SizeAndPrice = db.SizesAndPrices.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = db.Products.Find(db.SizesAndPrices.Find(id).ProductId), SizeAndPrice = db.SizesAndPrices.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            //return RedirectToAction("Index");
            //return RedirectToRoute(new { controller = "Home", action = "Index" });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Route("remove/{id:int}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SizeAndPrice.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
