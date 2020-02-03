using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class CookieUsageController : Controller
    {
        // GET: CookieUsage
        public ActionResult Index()
        {
            ViewBag.Title = "Cookie Usage";
            ViewBag.PageName = "cookie-usage";
            return View();
        }
    }
}