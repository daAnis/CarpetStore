using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetCarouselItem()
        {
            return PartialView("_GetCarouselItem");
        }

        public ActionResult GetProduct()
        {
            return PartialView("_GetProduct");
        }
    }
}
