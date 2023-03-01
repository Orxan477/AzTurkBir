using Aztobir.Business.ViewModels.Account;
using FluentValidation;

namespace Aztobir.Business.Validators.Account
{
    public class LoginVMValidators:AbstractValidator<LoginVM>
    {
        public LoginVMValidators()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(255);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(255);
        }
    }
}
