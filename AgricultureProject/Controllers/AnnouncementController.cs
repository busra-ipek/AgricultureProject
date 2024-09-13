using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Parse(DateTime.Now.ToShortDateString()); //girilen duyurularda tarih olarak bugünün tarihini alır.
            announcement.Status = false;
            //Her girilen verinin sql tablosunda Status alanı false olmaktadır.
            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            _announcementService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusTrue(int id)
        {
            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
            //Aktif Yap butonu'na bu metot ile işlevsellik verilir.
            //Verinin Status alanı True olarak değiştirilir.
        }

        public IActionResult ChangeStatusFalse(int id)
        {
            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
            //Pasif Yap butonu'na bu metot ile işlevsellik verilir.
            //Verinin Status alanı False olarak değiştirilir.

        }
        //Oluşturulan viewların çalışması için Program.cs dosyasında AddScoped metotlarının eklenmiş olması gerekmektedir.
    }
}
