using Microsoft.AspNetCore.Mvc;
using PluggedIn_V1._6.Models;
using PluggedIn_V1._6.Services;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PluggedIn_V1._6.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       

        [HttpPost]
        public IActionResult RegisterProcess(userModel userModel)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.AddUser(userModel))
            {
                return View("RegisterSuccess", userModel);

            }
            else
            {
                return View("RegisterFailure", userModel);
            }


            
        }


    }
    
}
