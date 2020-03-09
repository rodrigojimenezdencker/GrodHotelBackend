﻿using Microsoft.AspNetCore.Mvc;

namespace GrodHotelBackend.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageName = "not-found";
            return View("NotFound");
        }
    }
}