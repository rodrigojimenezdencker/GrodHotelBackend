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

        public class ViewModel
        {
            public IEnumerable<Hotels> Hotels { get; set; }
            public IEnumerable<Cities> Cities { get; set; }
        }

        private List<Hotels> GetHotels()
        {
            List<Hotels> hotels = _context.Hotels.ToList();
            return hotels;
        }

        private List<Cities> GetCities()
        {
            List<Cities> cities = _context.Cities.ToList();
            return cities;
        }

        // GET: Search
        public ActionResult Index(string hotelName)
        {
            ViewBag.Title = hotelName;
            ViewBag.PageName = "search";
            ViewModel mymodel = new ViewModel();
            mymodel.Hotels = GetHotels();
            mymodel.Cities = GetCities();
            return View(mymodel);
        }
    }
}