using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PCT.Web.Models;

namespace PCT.Web.Controllers
{
    [Route("frontend")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        /*
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            //https://docs.microsoft.com/es-es/aspnet/core/fundamentals/localization?view=aspnetcore-2.2
            //https://www.jeffogata.com/asp-net-core-localization-strings/
            _localizer = localizer;
        }
        */
        public HomeController()
        {
            
        }


        [Route("")]
        [Route("/")]
        [Route("home")]
        [Route("index")]
        public IActionResult Index()
        {

            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
