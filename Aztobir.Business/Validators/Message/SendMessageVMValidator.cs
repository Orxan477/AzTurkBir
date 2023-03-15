using Aztobir.Business.ViewModels.Home.University;
using FluentValidation;

namespace Aztobir.Business.Validators.Message
{
    public class SendMessageVMValidator:AbstractValidator<SendMessageVM>
    {
        public SendMessageVMValidator()
        {
            RuleFor(x => x.Body).NotEmpty().NotNull();
        }
    }
}
