using Microsoft.AspNetCore.Mvc;
using PluggedIn_V1._6.Models;
using PluggedIn_V1._6.Services;
using static PluggedIn_V1._6.Models.Model;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
//using Controller = System.Web.Mvc.Controller;
using System.Linq;

namespace PluggedIn_V1._6.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {




            //public IActionResult GetNearByLocations(string Currentlat, string Currentlng)
            //{


            //    using (var context = new PluggedInlogin())
            //    {


            //        var currentLocation = DbGeography.FromText("POINT( " + Currentlng + " " + Currentlat + " )");

            //        //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");



            //        var places = (from u in context.storeInfos
            //                      orderby u.GeoLocation.Distance(currentLocation)
            //                      select u).Take(4).Select(x => new PluggedIn_V1._6.Models.storeInfo() { storeName = x.storeName, lat = x.GeoLocation.Latitude, lng = x.GeoLocation.Longitude, Distance = x.GeoLocation.Distance(currentLocation) });
            //        var nearStore = places.ToList();


            //        return (IActionResult)Json(nearStore, JsonRequestBehavior.AllowGet);


            //    }

            
            return View();
        }



        //public IActionResult AccountView(storeInfo storeInfo)
        //{
        //    //SecurityService securityService = new SecurityService();

        //    return View();

        //}


    }
}
