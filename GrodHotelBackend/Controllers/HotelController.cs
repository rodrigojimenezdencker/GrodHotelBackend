using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;

namespace GROD_Hotel_Backend.Controllers
{
    public class HotelController : Controller
    {
        private readonly Context _context;

        public HotelController(Context context)
        {
            _context = context;
        }

        // GET: Hotel
        /* [HttpGet("/Hotels")]
        public ActionResult Index()
        {
            ViewBag.Title = "Hotel";
            ViewBag.PageName = "hotel";
            var hotels = _context.Hotels;
            return View(await hotels.ToListAsync());
        } */

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
            List<Hotels> hotelList = _context.Hotels.ToList();
            foreach (var hotel in hotelList)
            {
                string hotelName = hotel.Name.ToLower().Replace(" ", "_");
                if (hotelName.Equals(name.ToLower()))
                {
                    ViewBag.Title = hotel.Name;
                    if (checkAvailability(hotel))
                    {
                        return View(hotel);
                    } else
                    {
                        return View("NotAvailable");
                    }
                }
            }
            ViewBag.Title = "Hotel not found";
            ViewBag.test = "No existe";
            return View("NotAvailable");
        }

        public bool checkAvailability(Hotels hotel)
        {
            return hotel.Availability;
        }
    }
}