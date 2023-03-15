using Aztobir.Business.ViewModels.Home.News;
using FluentValidation;

namespace Aztobir.Business.Validators.News
{
    public class UpdateNewsVMValidator:AbstractValidator<UpdateNewsVM>
    {
        public UpdateNewsVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Content).MaximumLength(2000);
            RuleFor(x => x.Photo).NotNull().NotEmpty();
        }
    }
}
