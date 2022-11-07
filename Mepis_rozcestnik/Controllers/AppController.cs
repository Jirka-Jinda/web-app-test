using Microsoft.AspNetCore.Mvc;

namespace Mepis_rozcestnik.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
