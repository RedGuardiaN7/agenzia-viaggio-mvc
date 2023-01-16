using Microsoft.AspNetCore.Mvc;

namespace AgenziaViaggi.Controllers
{
    public class TourController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
