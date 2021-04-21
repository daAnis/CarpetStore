﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpetStoreASPNET.Controllers
{
    [Route("carpet")]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
