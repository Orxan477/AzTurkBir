using Aztobir.Business.ViewModels.Team;
using FluentValidation;

namespace Aztobir.Business.Validators.Team
{
    public class UpdateTeamVMValidator:AbstractValidator<UpdateTeamVM>
    {
        public UpdateTeamVMValidator()
        {
            RuleFor(x => x.FullName).MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
            RuleFor(x => x.Content).MaximumLength(1000);
            RuleFor(x => x.Facebook).MaximumLength(100);
            RuleFor(x => x.Linkedin).MaximumLength(100);
            RuleFor(x => x.Twitter).MaximumLength(100);
        }
    }
}
