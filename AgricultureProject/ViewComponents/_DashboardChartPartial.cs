using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _DashboardChartPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.bugday = 41; //Chart tablosu için verileri burada statik olarak tanımlayabiliriz.
            ViewBag.pirinc = 32;
            //Tablodan veri çekmek istersen context nesnesi oluşturmalısın.
            return View();
        }
    }
}
