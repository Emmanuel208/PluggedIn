using Microsoft.AspNetCore.Mvc;
using PluggedIn_V1._6.Models;
using PluggedIn_V1._6.Services;

namespace PluggedIn_V1._6.Controllers
{
    public class ContactController : Controller
    {
       // userContact db = new userContact();

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactProcess(userContact userContact)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.AddUserContact(userContact))
            {
                return View("SubmitSuccess", userContact);

            }
            else
            {
                return View("SubmitFailure", userContact);
            }



        }
    }
}
