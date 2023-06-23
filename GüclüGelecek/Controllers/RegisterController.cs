using Microsoft.AspNetCore.Mvc;

namespace GüclüGelecek.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult JobSeeker()
        {
            return View();
        }
        public IActionResult Employer()
        {
            return View();
        }
    }
}
