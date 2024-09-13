using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _DashboardNavbarPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext(); //Context sınıfından bir nesne türetilir.
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            //team tablosunda bulunan üye sayısını gösterir.
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();
            //Şu an bulunduğumuz ayda gelen mesaj sayısını gösterir.

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            return View();
        }
    }
}
