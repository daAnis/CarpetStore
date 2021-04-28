using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarpetStoreASPNET.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace CarpetStoreASPNET.Controllers
{
    [Route("api/product")]
    public class HomeRestController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = db.Products.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
                var products = db.Products.Where(p => p.Name.Contains(term)).ToList();

                

                return Content(JsonConvert.SerializeObject(products, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
