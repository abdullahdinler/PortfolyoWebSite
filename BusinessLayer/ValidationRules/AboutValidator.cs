using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alanı boş gecemezsiniz.");
            RuleFor(x => x.Img).NotEmpty().WithMessage("Bu alanı boş gecemezsiniz.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Bu alanı boş gecemezsiniz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alanı boş gecemezsiniz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Karekter sınırını aştınız.");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Karekter sınırını aştınız.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Karekter sınırını aştınız.");
           
        }
    }
}
