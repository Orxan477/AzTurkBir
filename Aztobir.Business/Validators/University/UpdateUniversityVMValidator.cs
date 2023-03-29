using Aztobir.Business.ViewModels.Home.University;
using FluentValidation;

namespace Aztobir.Business.Validators.University
{
    public class UpdateUniversityVMValidator:AbstractValidator<UpdateUniveresityVM>
    {
        public UpdateUniversityVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.Content).MaximumLength(3000);
            RuleFor(x => x.EducationLanguage).MaximumLength(10);
            RuleFor(x => x.EducationPlan).MaximumLength(3000);

        }
    }
}
