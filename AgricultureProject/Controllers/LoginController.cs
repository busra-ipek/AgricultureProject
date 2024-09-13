using AgricultureProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
   
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.userName, loginViewModel.password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı ");

                }
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        //Çıkış yap metodudur. Kyllanıcı çıkış yaptıktan sonra giriş yap  sayfasına yönlendirilir.

    }
}
//bool isPersistent: True olursa şifre tarayıcıda saklanır, beni hatırla gibi düşünebilirsin.
//bool lockoutOnFailure: True olursa kullanıcı şifreyi 5 kere yanlış girmesi durumunda sistemin belli bir süre locklanması anlamına gelir.