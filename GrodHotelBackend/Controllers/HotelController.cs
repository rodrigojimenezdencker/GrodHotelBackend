using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            ViewBag.Title = "Hotel";
            ViewBag.PageName = "hotel";
            return View();
        }
    }
}