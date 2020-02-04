using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GrodHotelBackend.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            ViewBag.PageName = "dashboard";
            return View();
        }
    }
}