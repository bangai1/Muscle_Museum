using Microsoft.AspNetCore.Mvc;

namespace Muscle_Museum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ticket");
        }
    }
}
