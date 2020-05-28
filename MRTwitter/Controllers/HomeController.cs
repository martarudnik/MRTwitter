using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRTwitter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var asd = System.Configuration.ConfigurationManager.AppSettings["emailAddress"];
            return View();
        }
    }
}