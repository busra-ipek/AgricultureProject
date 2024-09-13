using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _AnnouncementPartial : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;
		AgricultureContext c = new AgricultureContext();

		public _AnnouncementPartial(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
			// ID'lere göre duyuruları almak
			var announcement1 = _announcementService.GetById(1);
			var announcement2 = _announcementService.GetById(3);
			var announcement3 = _announcementService.GetById(4);

			// ViewBag'e atama
			ViewBag.AnnouncementTitle1 = announcement1?.Title;
			ViewBag.announcementDescription1 = announcement1?.Description;
			ViewBag.AnnouncementDate1 = announcement1?.Date.ToShortDateString();
			ViewBag.AnnouncementTitle2 = announcement2?.Title;
			ViewBag.AnnouncementDescription2 = announcement2?.Description;
			ViewBag.AnnouncementDate2 = announcement2?.Date.ToShortDateString();
			ViewBag.AnnouncementTitle3 = announcement3?.Title;
			ViewBag.AnnouncementDescription3 = announcement3?.Description;
			ViewBag.AnnouncementDate3 = announcement3?.Date.ToShortDateString(); 

			return View();
		}


	}
}
