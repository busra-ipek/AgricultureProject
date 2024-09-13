using AgricultureProject.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }

        //Ürün eklemek için bir view sayfası oluşturulur.
        [HttpGet]
        public IActionResult AddService()
        {
            //ServiceAddViewModel classında error kodları bulunur.
            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image,
                });
                //Değerler girilmişse tabloya kaydetme işlemi başarılı olur.
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(model);
            }
        }

        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.GetById(id); //Öncelikle hizmetin id'si bulunur, daha sonra silme işlemi yapılır.
            _serviceService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }


        //Oluşturulan viewların çalışması için Program.cs dosyasında AddScoped metotlarının eklenmiş olması gerekmektedir.
    }
}
