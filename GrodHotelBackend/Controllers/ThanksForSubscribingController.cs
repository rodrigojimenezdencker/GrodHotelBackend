using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class ThanksForSubscribingController : Controller
    {
        // GET: ThanksForSubscribing
        public ActionResult Index()
        {
            ViewBag.Title = "Thanks for Subscribing";
            ViewBag.PageName = "thanks-for-subscribing";
            return View();
        }
    }
}