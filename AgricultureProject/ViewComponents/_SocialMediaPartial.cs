using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _SocialMediaPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _SocialMediaPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        //SocialMedia için Controller oluşturmak yerine component oluşturduk.
        //Bu component içinde socialedia tablosunu-entity sini kullanacağımız için bunu ekledik.
        //Ama controller oluşturmamıza rağmen Manager,Service gibi classları
        //kullandığımız için Program.cs dosyasında SocialMedia için AddScoped metodunu kullanmalıyız.

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.GetListAll();
            return View(values);
        }
    }
}
