using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlığı boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(25).WithMessage("Lütfen en fazla 25 karakter girişi yapın");
            RuleFor(x => x.Title).MinimumLength(6).WithMessage("Lütfen en az 6 karakter girişi yapın");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklaması boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Lütfen en fazla 70 karakter girişi yapın");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Lütfen en az 15 karakter girişi yapın");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel adresi boş geçilemez");
        }
    }
}
                                                                    