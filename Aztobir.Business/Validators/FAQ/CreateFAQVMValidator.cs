using Aztobir.Business.ViewModels.Home.FAQ;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Validators.FAQ
{
    public class CreateFAQVMValidator:AbstractValidator<CreateFAQVM>
    {
        public CreateFAQVMValidator()
        {
            RuleFor(x => x.Question).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Response).NotEmpty().NotNull().MaximumLength(500);
        }
    }
}
