using Aztobir.Business.ViewModels.Home.Position;
using FluentValidation;

namespace Aztobir.Business.Validators.Position
{
    public class CreatePositionVMValidator:AbstractValidator<CreatePositionVM>
    {
        public CreatePositionVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
