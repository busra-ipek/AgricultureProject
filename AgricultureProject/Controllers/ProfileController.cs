using AgricultureProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);  //kullanıcını adına göre kullanıcı bulunur.
			UserEditViewModel userEditViewModel = new UserEditViewModel();


            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid)
            {

                if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
                {

                    values.Email = userEditViewModel.Mail;
                    values.PhoneNumber = userEditViewModel.Phone;

                    values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditViewModel.Password);
                    var result = await _userManager.UpdateAsync(values);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Şifreler uyuşmuyor. Lütfen tekrar kontrol edin.");
                }
            }

            return View();
        }

    }

}