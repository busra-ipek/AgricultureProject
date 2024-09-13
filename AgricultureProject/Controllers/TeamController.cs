using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class TeamController : Controller
    {
        //ServiceControllerda yaptığımız gibi yaparız.
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            ModelState.Clear();//Bu kod ile hata mesajlarını Türkçe olarak alabiliriz.
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team); //Validate team parametresinden gelen değerleri kontrol eder.
			// team parametresi ile oluşturduğumuz RuleFor kurallarını sağlayıp sağlamadığına bakmak için ValidationResult classını kullandık. 
			//ValidationResult kullanmak için using FluentValidation.Results kütüphanesini eklemelisin.

			if (result.IsValid)
            {
                _teamService.Insert(team);
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

        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.GetById(id);
            _teamService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamService.GetById(id); //Öncelikle güncelleme yapılacak olan alanın id'si bulunur.
			return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            //AddTeam için geçerli olan kurallar burada da geçerli olacaktır.

            ModelState.Clear();//Bu kod ile hata mesajlarını Türkçe olarak alabiliriz.
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team); //Validate team parametresinden gelen değerleri kontrol eder.
            if (result.IsValid)
            {
                _teamService.Update(team);
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
