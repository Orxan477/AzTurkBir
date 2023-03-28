using Aztobir.Business.ViewModels.Home.Faculty;
using FluentValidation;

namespace Aztobir.Business.Validators.Faculty
{
    public class FacultyCreateVMValidator:AbstractValidator<FacultyCreateVM>
    {
        public FacultyCreateVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty().NotNull();
        }
    }
}
