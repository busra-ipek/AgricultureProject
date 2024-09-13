using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _HeadPartial : ViewComponent
    {
        //Shared klasörü içine Components adında bir klasör oluştururuz. Daha sonra bu klasörü içinede bu
        //class ile aynı isme sahip olan yeni bir klasör ekleriz. Bu bir syntax kuralıdır.
        //Bu klasör içine Default adında yeni bir partial view ekleriz.
        public IViewComponentResult Invoke() //Invoke çağıracacağımız metodun ismidir.
        {
            return View();
        }
    }
}
