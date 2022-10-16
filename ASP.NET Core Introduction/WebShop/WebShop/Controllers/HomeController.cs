using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            this.HttpContext.Session.SetString("name", "pesho");


            //if (TempData.ContainsKey("LastAccessTime"))
            //{
                // TempData.Keep("LastAccessTime");

            //    return Ok(TempData["LastAccessTime"]);

            //}

            //TempData["LastAccessTime"] = DateTime.Now;
            //this.HttpContext.Response.Cookies.Append("mycookie", "Pesho");

            //this.HttpContext.Response.Cookies.Append("mycookie", "Pesho",new CookieOptions()
            //{

            //});
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            //string? name= this.HttpContext.Session.GetString("name");

            //if (!string.IsNullOrEmpty(name))
            //{
            //    return Ok(name);
            //}

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}