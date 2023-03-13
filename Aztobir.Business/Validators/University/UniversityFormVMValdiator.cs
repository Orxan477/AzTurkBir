using Aztobir.Business.ViewModels.University;
using FluentValidation;

namespace Aztobir.Business.Validators.University
{
    public class UniversityFormVMValdiator:AbstractValidator<UniversityFormVM>
    {
        public UniversityFormVMValdiator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Message).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(x => x.Email).EmailAddress().NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
