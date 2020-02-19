using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;

namespace GrodHotelBackend.Controllers
{
    public class RoomController : Controller
    {
        private readonly Context _context;

        public RoomController(Context context)
        {
            _context = context;
        }

        // GET: Room
        [HttpGet("/Room")]
        public ActionResult Index()
        {
            ViewBag.Title = "Room";
            ViewBag.PageName = "room";
            return View();
        } 

        // GET: Room
        [HttpGet("/Room/{id:int?}")]
        public ActionResult Index(int id)
        {
            Rooms room = _context.Rooms.Find(id);
            if (room == null)
            {
                ViewBag.Title = "Room not found";
                ViewBag.test = "No existe";
                return View("NotAvailable");
            }

            if (checkAvailability(room))
            {
                ViewBag.PageName = "room";
                return View(room);
            }
            else
            {
                return View("NotAvailable");
            }
        }

        public bool checkAvailability(Rooms room)
        {
            return room.Availability;
        }
    }
}