using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
