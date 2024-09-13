using System.ComponentModel.DataAnnotations;

namespace AgricultureProject.Models
{
    public class UserEditViewModel
    {
        //Kullanıcının güncelleyebileceği özellikler tanımlanmıştır.
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
    }
}
