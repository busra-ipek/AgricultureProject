using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
		//Burada Address tablosuna ait kısıtlamalar belirlenecektir.
		//RuleFor kuralları constructor içine yazılmazsa çalışmayacaktır.

		public AddressValidator()
        {
            RuleFor(x => x.AddressName).NotEmpty().WithMessage("Açıklama 1 boş geçilemez");
			//Bu kurala göre AddressName alanı boş olamaz, boş olursa hata mesajı gösterilir.
			RuleFor(x => x.City).NotEmpty().WithMessage("Açıklama 2 boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Açıklama 3 boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Açıklama 4 boş geçilemez");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez");
            RuleFor(x => x.AddressName).MaximumLength(50).WithMessage("Lütfen açıklamayı kısaltın");
            RuleFor(x => x.City).MaximumLength(30).WithMessage("Lütfen açıklamayı kısaltın");
            RuleFor(x => x.PhoneNumber).MaximumLength(30).WithMessage("Lütfen açıklamayı kısaltın");
            RuleFor(x => x.Mail).MaximumLength(30).WithMessage("Lütfen açıklamayı kısaltın");
			//Bu kurala göre mail kısmı maximum karakter sayısı 30 olmalıdır.
		}
	}
}
