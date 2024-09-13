using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }

        //Adres eklemeye gerek yoktur. Sadece bir kere adres eklenecektir ve gerekli olursa adres güncellenecektir.
        //Adres silme işlemide olmayacaktır. Sadece listeleme ve düzenleme işlemi olacaktır.


        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var values = _addressService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAddress(Address address)
        {

            ModelState.Clear();//Bu kod ile hata mesajlarını Türkçe olarak alabiliriz.
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(address); //Validate team parametresinden gelen değerleri kontrol eder.
            if (result.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    //ImageValidatorda yazmış olduğumuz hata mesajları gösterilir.
                }
            }
            //Bunları yazdıktan sonra viewa giderek <span> etiketini ekleriz.
            return View();
        }

        //Oluşturulan viewların çalışması için Program.cs dosyasında AddScoped metotlarının eklenmiş olması gerekmektedir.
    }
}
