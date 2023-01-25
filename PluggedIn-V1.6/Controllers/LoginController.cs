using Microsoft.AspNetCore.Mvc;
using PluggedIn_V1._6.Models;
using PluggedIn_V1._6.Services;

namespace PluggedIn_V1._6.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(userModel userModel)
        {
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);

            }
            else
            {
                return View("LoginFailure",userModel);
            }


           
        }
    }
}
