using Aztobir.Business.ViewModels.Home.Position;
using FluentValidation;

namespace Aztobir.Business.Validators.Position
{
    public class UpdatePositionVMValidator:AbstractValidator<UpdatePositionVM>
    {
        public UpdatePositionVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
