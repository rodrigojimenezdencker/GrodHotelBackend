using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GROD_Hotel_Backend.Controllers
{
    public class BookingController : Controller
    {
        private readonly Context _context;

        public BookingController(Context context)
        {
            _context = context;
        }

        // POST: Room by ID
        [HttpPost("/Booking/{id:int?}")]
        public ActionResult Index(int id)
        {
            ViewBag.PageName = "booking";
            Rooms room = _context.Rooms.Find(id);

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Page not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = "Booking-" + room.Name;
            return View(room);
        }

        // POST: Room by slug
        [HttpPost("/Booking/{name?}")]
        public ActionResult Index(string name)
        {
            ViewBag.PageName = "booking";
            Rooms room = _context.Rooms.Where(room => room.Slug.Equals(name)).FirstOrDefault();

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Page not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = "Booking-" + room.Name;
            return View(room);
        }
    }
}