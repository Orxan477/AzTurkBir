using Aztobir.Business.ViewModels.Home.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Validators.Contact
{
    public class CreateContactVMValdiator:AbstractValidator<CreateContactVM>
    {
        public CreateContactVMValdiator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Phone).NotEmpty().NotNull().MaximumLength(14);
            RuleFor(x => x.Subject).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Message).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
