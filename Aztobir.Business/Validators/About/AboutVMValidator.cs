using Aztobir.Business.ViewModels.About;
using FluentValidation;

namespace Aztobir.Business.Validators.About
{
    public class AboutVMValidator:AbstractValidator<AboutVM>
    {
        public AboutVMValidator()
        {
            RuleFor(x => x.Content).MaximumLength(1000);
        }
    }
}
