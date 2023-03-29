using Aztobir.Business.ViewModels.Home.University;
using FluentValidation;

namespace Aztobir.Business.Validators.University
{
    public class CreateUniversityVMValidator:AbstractValidator<CreateUniversityVM>
    {
        public CreateUniversityVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(3000);
            RuleFor(x => x.CityId).NotEmpty().NotNull();
            RuleFor(x => x.Photo).NotEmpty().NotNull();
            RuleFor(x => x.EducationLanguage).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(x => x.StudentCount).NotEmpty().NotNull();
            RuleFor(x => x.FacultyCount).NotEmpty().NotNull();
            RuleFor(x => x.EducationPlan).NotEmpty().NotNull().MaximumLength(3000);
            RuleFor(x => x.FacultiesId).NotEmpty().NotNull();
        }
    }
}
