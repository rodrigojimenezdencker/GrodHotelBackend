using Microsoft.AspNetCore.Mvc;

namespace GROD_Hotel_Backend.Controllers
{
    public class ThanksForContactingUsController : Controller
    {
        // GET: ThanksForContactingUs
        public ActionResult Index()
        {
            ViewBag.Title = "Thanks for Contacting Us";
            ViewBag.PageName = "thanks-for-contacting-us";
            return View();
        }
    }
}