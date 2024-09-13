using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
