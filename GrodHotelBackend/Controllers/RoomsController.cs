using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GrodHotelBackend.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Room";
            ViewBag.PageName = "room";
            return View();
        }
    }
}