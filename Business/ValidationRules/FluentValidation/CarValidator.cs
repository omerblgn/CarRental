using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotNull();

            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.ModelYear).GreaterThan(1800);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
        }
    }
}
