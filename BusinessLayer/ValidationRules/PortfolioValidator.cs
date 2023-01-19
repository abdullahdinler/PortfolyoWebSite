using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Img).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}
