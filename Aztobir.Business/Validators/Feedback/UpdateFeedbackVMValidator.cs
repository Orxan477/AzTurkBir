using Aztobir.Business.ViewModels.Home.Feedback;
using FluentValidation;

namespace Aztobir.Business.Validators.Feedback
{
    public class UpdateFeedbackVMValidator:AbstractValidator<UpdateFeedbackVM>
    {
        public UpdateFeedbackVMValidator()
        {
            RuleFor(x => x.FullName).MaximumLength(100);
            RuleFor(x => x.Comment).MaximumLength(200);
        }
    }
}
