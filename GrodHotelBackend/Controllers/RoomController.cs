using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            Rooms room = _context.Rooms
                .Include(x => x.RoomComodities)
                .ThenInclude(roomComodities => roomComodities.Comodities)
                .FirstOrDefault(room => room.Id == id);

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
    }
}