using FluentValidation;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;

namespace MarsRover.Application.Validators
{
    public class CoordinateValidator : AbstractValidator<Coordinate>
    {
        public CoordinateValidator()
        {
            RuleFor(p => p.X)
                .GreaterThan(0);
            RuleFor(p => p.Y)
                .GreaterThan(0);
        }
    }
}