using Aztobir.Business.ViewModels.About;
using FluentValidation;

namespace Aztobir.Business.Validators.Goal
{
    public class GoalUpdateVMValidator:AbstractValidator<GoalUpdateVM>
    {
        public GoalUpdateVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.Content).MaximumLength(200);
        }
    }
}
