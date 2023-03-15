using Aztobir.Business.ViewModels.Home.City;
using FluentValidation;

namespace Aztobir.Business.Validators.City
{
    public class CreateCityVMValidator:AbstractValidator<CityCreateVM>
    {
        public CreateCityVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
