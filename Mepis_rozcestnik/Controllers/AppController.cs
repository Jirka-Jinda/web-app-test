using Microsoft.AspNetCore.Mvc;

namespace Mepis_rozcestnik.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult show_oos()
        {
            return View("out_of_service_prod");
        }
    }
}
