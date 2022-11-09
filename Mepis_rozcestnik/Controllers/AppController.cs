using Mepis_rozcestnik.Models;
using Microsoft.AspNetCore.Mvc;


namespace Mepis_rozcestnik.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult determine_url()
        {
            var res = Models.determine_url.determine(Request.Form["env"], Request.Form["usr"], Request.Form["btn"]);
            if (Models.Check_apps_status.check_status(res))
            {
                return Redirect(res);
            }
            else
            {
                if (Request.Form["env"] == "prod")
                    return View("out_of_service_prod");
                else
                    return View("out_of_service_test");
            }
        }
    }
}
