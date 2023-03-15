using Aztobir.Business.ViewModels.Home.FAQ;
using FluentValidation;

namespace Aztobir.Business.Validators.FAQ
{
    public class UpdateFAQVMValidator:AbstractValidator<UpdateFAQVM>
    {
        public UpdateFAQVMValidator()
        {
                RuleFor(x => x.Question).MaximumLength(100);
                RuleFor(x => x.Response).MaximumLength(500);
            
        }
    }
}