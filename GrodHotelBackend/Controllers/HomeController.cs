﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "GROD Hotel";
            ViewBag.PageName = "index";
            return View();
        }
    }
}