using Aztobir.Business.ViewModels.Home.City;
using FluentValidation;

namespace Aztobir.Business.Validators.City
{
    public class UpdateCityVMValidator:AbstractValidator<CityUpdateVM>
    {
        public UpdateCityVMValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
