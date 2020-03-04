using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GrodHotelBackend.Controllers
{
    public class HotelController : Controller
    {
        private readonly Context _context;

        public HotelController(Context context)
        {
            _context = context;
        }

        public class ViewModel
        {
            public IEnumerable<Hotels> Hotels { get; set; }
            public IEnumerable<Clients> Clients { get; set; }
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

        // GET: Hotel
        [HttpGet("/Hotel/{id:int?}")]
        public ActionResult Index(int id)
        {
            Hotels hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                ViewBag.Title = "Hotel not found";
                ViewBag.test = "No existe";
                return View("NotAvailable");
            }

            ViewBag.Title = hotel.Name;
            if (checkAvailability(hotel))
            {
                ViewBag.PageName = "hotel";
                return View(hotel);
            } else
            {
                return View("NotAvailable");
            }
        }

        // GET: Hotel
        [HttpGet("/Hotel/{name?}")]
        public ActionResult Index(string name)
        {
            ViewBag.PageName = "hotel";
            Hotels hotel = _context.Hotels.Where(hotel => hotel.Slug == name).FirstOrDefault();

            if (hotel != null)
            {
                string hotelName = hotel.Name.ToLower().Replace(" ", "_");

                if (hotelName.Equals(name.ToLower()))
                {
                    ViewBag.Available = hotel.Availability;
                    ViewBag.Title = hotel.Name;
                    if (checkAvailability(hotel))
                    {
                        return View(hotel);
                    }
                    else
                    {
                        return View(hotel);
                    }
                }
            }

            ViewBag.Title = "Hotel not found";
            ViewBag.test = "No existe";
            return View("NotFound");
        }

        public bool checkAvailability(Hotels hotel)
        {
            return hotel.Availability;
        }
    }
}