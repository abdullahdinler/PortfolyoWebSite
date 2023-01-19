using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.SkillValue).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Karekter sınırını geçtiniz.");
            RuleFor(x => x.Txt).MaximumLength(100).WithMessage("Karekter sınırını geçtiniz.");
        }
    }
}
