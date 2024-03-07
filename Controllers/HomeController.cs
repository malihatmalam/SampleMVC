using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleMVC.Controllers
{
    // [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View("About");
            // return Content("This.....");
        }

        [Route("Syut")]
        public IActionResult Index(string name){
            return Content($"Inputan name adalah = {name}");
            // return Content("This.....");
        }

        public IActionResult About(){
            return Content("About.....");
        }

        public IActionResult Contact(){
            return View();
        }
    }

}