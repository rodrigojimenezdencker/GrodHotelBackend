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
        public ActionResult Index(DateTime EntyDate, DateTime LeavingDate, int AdultNumbers, int MinorNumbers, decimal MinimumPrice, decimal MaximumPrice, strng City)
        {
            ViewBag.Title = ciudad;
            Filters filters = new Filters();
            filters.AdultNumbers = 
            ViewBag.PageName = "search";
            IList<Hotels> hotel = _context.Hotels.Where(el => el.Availability == true).ToList();
            return View(hotel);
        }
    }
}