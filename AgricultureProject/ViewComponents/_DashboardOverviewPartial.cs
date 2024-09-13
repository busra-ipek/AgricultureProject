using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{

    public class _DashboardOverviewPartial : ViewComponent
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
            //Announcements tablosunda Status alanı true olanlar gösterilir.
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.urunPazarlama = c.Teams.Where(x => x.Task == "Ürün Pazarlama").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.sutUretici = c.Teams.Where(x => x.Task == "Süt ve Süt Ürünleri Yöneticisi").Select(y => y.PersonName).FirstOrDefault();
			ViewBag.ciftlikYonetimi = c.Teams.Where(x => x.Task == "Çiftlik Kaynakları Yönetimi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.uretimKoordinatoru = c.Teams.Where(x => x.Task == "Üretim Koordinatörü").Select(y => y.PersonName).FirstOrDefault();
			//where firstordefault bir şart koymak için kullanılan bir entity frameworktür. where de Task alanı benim parametre olarak yazdığım 
			//"Üretim Koordinatörü'ne eşit olan değer mi diye öncelikle kontrol ediyor.
			// Firstordefault ise gönderilen task değerine sahip olan satırdan PersonName alanını direkt olarak hafızaya alır.

			return View();
        }
    }
}
