﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class BookingCompletedController : Controller
    {
        // GET: BookingCompleted
        public ActionResult Index()
        {
            ViewBag.Title = "Booking Completed";
            ViewBag.PageName = "booking-completed";
            return View();
        }
    }
}