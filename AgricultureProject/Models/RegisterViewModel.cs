using System.ComponentModel.DataAnnotations;

namespace AgricultureProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen ad soyad giriniz!")]
        public string? nameSurname { get; set; }
        
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz!")]
        public string? userName { get; set; }

        [Required(ErrorMessage = "Lütfen mail giriniz!")]
        public string? mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz!")]
        public string password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("password", ErrorMessage = "Şifreler uyumlu değil, kontrol ediniz!")]
        public string passwordConfirm { get; set; }

    }
}
