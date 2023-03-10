using Aztobir.Business.ViewModels.Home.University;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Validators.University
{
    public class CreateUniPhotosVMValidator:AbstractValidator<CreateUniPhotosVM>
    {
        public CreateUniPhotosVMValidator()
        {
            RuleFor(x => x.Photos).NotEmpty().NotNull();
        }
    }
}
