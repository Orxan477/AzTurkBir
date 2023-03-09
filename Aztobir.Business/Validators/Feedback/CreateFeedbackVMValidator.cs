using Aztobir.Business.ViewModels.Home.Feedback;
using FluentValidation;

namespace Aztobir.Business.Validators.Feedback
{
    public class CreateFeedbackVMValidator:AbstractValidator<CreateFeedbackVM>
    {
        public CreateFeedbackVMValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Comment).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.UniversityId).NotNull().NotEmpty();
            RuleFor(x => x.Photo).NotNull().NotEmpty();
        }
    }
}
