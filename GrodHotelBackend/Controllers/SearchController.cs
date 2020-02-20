using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;

namespace GrodHotelBackend.Controllers
{
    public class SearchController : Controller
    {
        private readonly Context _context;

        public SearchController(Context context)
        {
            _context = context;
        }
        // GET: Search
        public ActionResult Index(string hotelName)
        {
            ViewBag.Title = hotelName;
            ViewBag.PageName = "search";
            IList<Hotels> hotel = _context.Hotels.Where(el => el.Availability == true).ToList();
            return View(hotel);
        }
    }
}