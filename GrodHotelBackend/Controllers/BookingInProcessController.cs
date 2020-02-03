using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class BookingInProcessController : Controller
    {
        // GET: BookingInProcess
        public ActionResult Index()
        {
            ViewBag.Title = "Booking in Process";
            ViewBag.PageName = "booking-in-process";
            return View();
        }
    }
}