using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

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
            public IEnumerable<Rooms> Rooms { get; set; }
            public IEnumerable<Cities> Cities { get; set; }
        }

        private List<Cities> GetCities()
        {
            List<Cities> cities = _context.Cities.ToList();
            return cities;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewModel mymodel = new ViewModel
            {
                Cities = GetCities()
            };

            ViewData["min_price"] = _context.Rooms.Min(x => x.Price).ToString().Replace(",", ".");
            ViewData["max_price"] = _context.Rooms.Max(x => x.Price).ToString().Replace(",", ".");
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            Filters filters = new Filters();
            filters.EntryDate = DateTime.Parse(form["entry_date"]);
            filters.LeavingDate = DateTime.Parse(form["leaving_date"]);            
            filters.AdultNumbers = int.Parse(form["numberAdults"]);
            filters.MinorNumbers = int.Parse(form["numberMinors"]);
            try
            {
                filters.MinimumPrice = decimal.Parse(form["min_price"]);
                filters.MaximumPrice = decimal.Parse(form["max_price"]);
            } catch(Exception)
            {

            }
            filters.City = int.Parse(form["city"]);
            Searcher searcher = new Searcher(_context);
            ViewModel mymodel = new ViewModel
            {
                Rooms = searcher.Run(filters),
                Cities = GetCities()
            };
            return View(mymodel);
        }
        
    }
}