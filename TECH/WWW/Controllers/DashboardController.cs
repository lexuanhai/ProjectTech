using Microsoft.AspNetCore.Mvc;

namespace WWW.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
