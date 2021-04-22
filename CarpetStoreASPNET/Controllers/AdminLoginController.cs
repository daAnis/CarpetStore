using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Controllers
{
    [Route("login")]
    public class AdminLoginController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToRoute(new { area = "admin", controller = "Home", action = "Index" });
            }
            else
            {
                ViewBag.error = "Invalid";
                return View("Index");
            }
        }
    }

}
