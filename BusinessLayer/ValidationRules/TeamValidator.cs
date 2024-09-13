using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Ad Soyad bilgisi boş geçilemez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.PersonName).MinimumLength(4).WithMessage("Lütfen en az 4 karakterli veri girişi yapınız");
            RuleFor(x => x.Task).NotEmpty().WithMessage("Görev kısmını boş geçilemez");
            RuleFor(x => x.Task).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.Task).MinimumLength(3).WithMessage("Lütfen en az 3 karakterli veri girişi yapınız");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel adresi boş geçilemez");
            //İsteğe bağlı olarak farklı propertyler için de error rules yazabilirsin.

        }
    }
}
