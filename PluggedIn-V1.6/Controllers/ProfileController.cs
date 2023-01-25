using Microsoft.AspNetCore.Mvc;

namespace PluggedIn_V1._6.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
