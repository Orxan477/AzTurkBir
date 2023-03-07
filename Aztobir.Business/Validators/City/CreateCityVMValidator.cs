using Aztobir.Business.ViewModels.Home.City;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Validators.City
{
    public class CreateCityVMValidator:AbstractValidator<CityVM>
    {
        public CreateCityVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
