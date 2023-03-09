using Aztobir.Business.ViewModels.Home.News;
using FluentValidation;

namespace Aztobir.Business.Validators.News
{
    public class CreateNewsVMValidator: AbstractValidator<CreateNewsVM>
    {
        public CreateNewsVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Content).NotEmpty().NotNull().MaximumLength(2000);
            RuleFor(x => x.Photo).NotNull().NotEmpty();
        }
    }
}
