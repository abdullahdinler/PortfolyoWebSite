using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Position).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.WorkInfo).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.WorkplaceName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Position).MaximumLength(100).WithMessage("Karekter aşımı gerçekleşti.");
            RuleFor(x => x.WorkInfo).MaximumLength(1000).WithMessage("Karekter aşımı gerçekleşti.");
            RuleFor(x => x.WorkplaceName).MaximumLength(100).WithMessage("Karekter aşımı gerçekleşti.");
        }
    }
}
