using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }
    }
}