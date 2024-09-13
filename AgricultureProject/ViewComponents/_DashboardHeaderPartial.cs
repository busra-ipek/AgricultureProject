using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _DashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
