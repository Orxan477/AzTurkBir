using Aztobir.Business.ViewModels.Team;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Validators.Team
{
    public class CreateTeamVMValidator:AbstractValidator<CreateTeamVM>
    {
        public CreateTeamVMValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.PositionId).NotEmpty().NotNull();
            RuleFor(x => x.Photo).NotEmpty().NotNull();
            RuleFor(x => x.Phone).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Content).NotEmpty().NotNull().MaximumLength(1000);
            RuleFor(x => x.Facebook).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Linkedin).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Twitter).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
