using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            ViewBag.Title = "Booking";
            ViewBag.PageName = "booking";
            return View();
        }
    }
}