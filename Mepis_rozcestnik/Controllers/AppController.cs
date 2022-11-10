using Mepis_rozcestnik.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace Mepis_rozcestnik.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult process_form()
        {
            var btn = Request.Form["btn"];
            if (StringValues.IsNullOrEmpty(btn))
            {
                var env = Request.Form["env"];
                var collection = announcements_collection.get_announ_by_env(env);
                return View("Index", collection);
            }
            else
            {
                var res = Models.determine_url.determine(Request.Form["env"], Request.Form["usr"], btn);
                if (Models.Check_apps_status.check_status(res).Result)
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
}
