using Aztobir.Business.ViewModels.Home.Faculty;
using FluentValidation;

namespace Aztobir.Business.Validators.Faculty
{
    public class FacultyUpdateVMValidator:AbstractValidator<FacultyUpdateVM>
    {
        public FacultyUpdateVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.UniversityId).NotEmpty().NotNull();
        }
    }
}
