using _3.BirdsApplication.DTOs;
using FluentValidation;

namespace _4.BirdsInfrastructure.Validators
{
    public class CountryValidator : AbstractValidator<CountryDto>
    {
        public CountryValidator()
        {
            RuleFor(country => country.NameCountry)
                .Length(1, 20)
                .WithMessage("La longitud del nombre de la ciudad debe estar entre 1 y 20 caracteres")
                .NotNull()
                .WithMessage("El nombre de la ciudad no puede ser nulo");        
        }
    }
}
