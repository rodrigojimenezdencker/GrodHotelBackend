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

        // GET: Hotel by ID
        [HttpGet("/Hotel/{id:int?}")]
        public ActionResult Index(int id)
        {
            ViewBag.PageName = "hotel";
            Hotels hotel = _context.Hotels
                .Include(x => x.Rooms)
                .FirstOrDefault(hotel => hotel.Id == id);

            if (hotel == null)
            {
                ViewBag.NotFoundMessage = "Hotel not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = hotel.Availability;
            ViewBag.Title = hotel.Name;
            return View(hotel);
        }

        // GET: Hotel by slug
        [HttpGet("/Hotel/{name?}")]
        public ActionResult Index(string name)
        {
            ViewBag.PageName = "hotel";
            Hotels hotel = _context.Hotels
                .Include(x => x.Rooms)
                .FirstOrDefault(hotel => hotel.Slug == name);

            if (hotel == null)
            {
                ViewBag.NotFoundMessage = "Hotel not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = hotel.Availability;
            ViewBag.Title = hotel.Name;
            return View(hotel);
        }
    }
}