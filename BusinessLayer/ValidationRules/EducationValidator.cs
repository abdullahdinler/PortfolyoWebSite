using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class EducationValidator:AbstractValidator<Education>
    {
        public EducationValidator()
        {
            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.EpisodeName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.SchoolName).MaximumLength(50).WithMessage("Karekter aşımı gerçekleşti.");
            RuleFor(x => x.EpisodeName).MaximumLength(50).WithMessage("Karekter aşımı gerçekleşti.");
            RuleFor(x => x.Explanation).MaximumLength(150).WithMessage("Karekter aşımı gerçekleşti.");
        }
    }
}
