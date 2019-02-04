using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCT.Web.Controllers.Backend
{
    [Route("backend")]
    public class BackendHomeController : Controller
    {
        private const string ROOT_PATH = "~/Views/Backend/";
        private const string INDEX_VIEW = ROOT_PATH+ "Index.cshtml";

        [Route("home")]
        [Route("index")]
        public IActionResult Index()
        {
            return View(INDEX_VIEW);
        }
    }
}