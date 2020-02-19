using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GrodHotelBackend.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            ViewBag.Title = "Search";
            ViewBag.PageName = "search";
            return View();
        }
    }
}