using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;

namespace GrodHotelBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public class ViewModel
        {
            public IEnumerable<Hotels> Hotels { get; set; }
            public IEnumerable<Clients> Clients { get; set; }
            public IEnumerable<Cities> Cities { get; set; }
        }

        private List<Hotels> GetHotels()
        {
            List<Hotels> hotels = _context.Hotels.ToList();
            return hotels;
        }

        private List<Clients> GetClients()
        {
            List<Clients> clients = _context.Clients.ToList();
            return clients;
        }
        private List<Cities> GetCities()
        {
            List<Cities> cities = _context.Cities.ToList();
            return cities;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "GROD Hotel";
            ViewBag.PageName = "index";
            ViewModel mymodel = new ViewModel();
            mymodel.Hotels = GetHotels();
            mymodel.Clients = GetClients();
            mymodel.Cities = GetCities();
            return View(mymodel);
        }
    }
}