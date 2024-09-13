using System.ComponentModel.DataAnnotations;

namespace AgricultureProject.Models
{
    public class ServiceAddViewModel
    {
        //Buradaki hata kodları değerler girilmediğinde gösterilecektir.
        //İstersen başka hata mesajlarıda ekleyebilirsin, en az 3 karakterden oluşsun gibi hata mesajlarıda eklenebilir.
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public string? Title { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string? Description { get; set; }

        [Display(Name = "Görsel Adresi")]
        [Required(ErrorMessage = "Görsel adresi boş geçilemez")]
        public string? Image { get; set; }
    }
}
