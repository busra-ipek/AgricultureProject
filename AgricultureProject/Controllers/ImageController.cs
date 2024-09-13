using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _imageService.GetListAll();
            return View(values);
        }

        [HttpGet] //AddImage metodunun sayfa yüklenince çalışmasını sağlar.
		public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost] //Sayfada bir butona basıldığında veya herhangi bir işlem yapıldığında alttaki metodu çalıştırır.
		public IActionResult AddImage(Image image)
        {
            ModelState.Clear();//Bu kod ile hata mesajlarını Türkçe olarak alabiliriz.
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(image); //Validate team parametresinden gelen değerleri kontrol eder.
            if (result.IsValid)
            {
                _imageService.Insert(image);
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
            //Bunları yazdıktan sonra AddTeam viewa giderek <span> etiketini ekleriz.
            return View();
        }

        public IActionResult DeleteImage(int id)
        {
            var values = _imageService.GetById(id);
            _imageService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var values = _imageService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditImage(Image image)
        {
            //AddImage için geçerli olan kurallar burada da geçerli olacaktır.

            ModelState.Clear();//Bu kod ile hata mesajlarını Türkçe olarak alabiliriz.
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(image); //Validate imageparametresinden gelen değerleri kontrol eder.
            if (result.IsValid)
            {
                _imageService.Update(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    //TeamValidatorda yazmış olduğumuz hata mesajları gösterilir.
                }
            }
            //Bunları yazdıktan sonra AddTeam viewa giderek <span> etiketini ekleriz.
            return View();
        }
        //Oluşturulan viewların çalışması için Program.cs dosyasında AddScoped metotlarının eklenmiş olması gerekmektedir.
    }
}
