using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class PersonalDataUsageController : Controller
    {
        // GET: PersonalDataUsage
        public ActionResult Index()
        {
            ViewBag.Title = "Personal Data Usage";
            ViewBag.PageName = "personal-data-usage";
            return View();
        }
    }
}