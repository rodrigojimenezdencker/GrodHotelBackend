using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GrodHotelBackend.Controllers
{
    public class RoomController : Controller
    {
        private readonly Context _context;

        public RoomController(Context context)
        {
            _context = context;
        }

        // GET: Room by ID
        [HttpGet("/Room/{id:int?}")]
        public ActionResult Index(int id)
        {
            ViewBag.PageName = "room";
            Rooms room = _context.Rooms.Find(id);

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Room not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = room.Name;
            return View(room);
        }

        // GET: Room by slug
        [HttpGet("/Room/{name?}")]
        public ActionResult Index(string name)
        {
            ViewBag.PageName = "room";
            Rooms room = _context.Rooms.Where(room => room.Slug.Equals(name)).FirstOrDefault();

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Room not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = room.Name;
            return View(room);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection form, int id)
        {
            Filters filters = new Filters();
            filters.EntryDate = DateTime.Parse(form["entry_date"]);
            filters.LeavingDate = DateTime.Parse(form["leaving_date"]);
            filters.AdultNumbers = int.Parse(form["numberAdults"]);
            filters.MinorNumbers = int.Parse(form["numberMinors"]);
            Rooms room = _context.Rooms.Find(id);
            Searcher searcher = new Searcher(_context);
            var roomBooking = searcher.isAvailable(filters, room);
            return View(room);
        }
    }
}