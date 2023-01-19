using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Bu alan boş gecilemez.");
            RuleFor(x => x.FullName).MaximumLength(100).WithMessage("Karekter aşımı gerçekleşti.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş gecilemez.");
            RuleFor(x => x.MessageTxt).NotEmpty().WithMessage("Bu alan boş gecilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş gecilemez.");
        }
    }
}
