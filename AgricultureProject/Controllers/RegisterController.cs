using AgricultureProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Security.Principal;

namespace AgricultureProject.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			// Bu metod, kullanıcıya kayıt formunu görüntülemek için kullanılır.
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
		{
			if(ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					Email = registerViewModel.mail,
					NameSurname = registerViewModel.nameSurname,
					UserName = registerViewModel.userName,
				};

				var result = await _userManager.CreateAsync(appUser, registerViewModel.password);
				//Şifreyle birlikte yeni kullanıcıyı oluşturur._userManager, ASP.NET Core Identity'nin 
				//kullanıcı yönetimi için kullanılan bir servisidir.

				if (result.Succeeded)
				{
					return RedirectToAction("Index","Login");
					//Kullanıcı başarıyla oluşturulmuşsa, kullanıcıyı "Login" sayfasına yönlendirir.
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("",item.Description);
						//Eğer kullanıcı oluşturma başarısız olursa, hataları alır ve ModelState içine ekleyerek
						//aynı sayfayı tekrar kullanıcıya sunar, böylece hatalar görüntülenir.
					}
				}
			}
			return View();
			//Kullanıcıyı kaydetmek için form verilerini alır, validasyon yapar ve eğer her şey yolundaysa
			//kullanıcıyı oluşturur. Kullanıcı başarıyla oluşturulursa giriş sayfasına yönlendirir;
			//aksi takdirde hataları gösterir.
		}
	}
}
/*Identity kütüphanesi için şifre formatı:
 *en az 6 karakter
 * 1 küçük harf
 * 1 büyük harf
 * 1 tane sembol
 * Bu şekilde şifre oluşturulmalıdır. Yoksa sql de aspnetusers tablosuna veri girişi yapılmaz.
 */