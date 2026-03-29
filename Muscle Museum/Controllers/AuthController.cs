using Microsoft.AspNetCore.Mvc;
using Muscle_Museum.Models;

namespace Muscle_Museum.Controllers
{
    public class AuthController : Controller
    {
     
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(Login_ViewModel model)
            {
                if (model.Username == "admin" && model.Password == 123 )
                {
                    HttpContext.Session.SetString("User", model.Username);

                    // 🔥 DIREKT TICKET'A GİT
                    return RedirectToAction("Index", "Ticket");
                }

                ModelState.AddModelError("", "Hatalı giriş");
                return View(model);
            }
     }
    
}
