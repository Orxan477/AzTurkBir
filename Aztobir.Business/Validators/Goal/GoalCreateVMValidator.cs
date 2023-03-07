using FluentValidation;

namespace Aztobir.Business.Validators.Goal
{
    public class GoalCreateVMValidator : AbstractValidator<ViewModels.About.GoalCreateVM>
    {
        public GoalCreateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(200);
        }
    }
}
