using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class LandToPlateauCommandValidator : AbstractValidator<LandToPlateauCommand>
    {
        public LandToPlateauCommandValidator()
        {
            RuleFor(p => p.PlateauId)
                .NotEmpty();
            RuleFor(p => p.RoverId)
                .NotEmpty();
            RuleFor(p => p.Coordinate)
                .NotNull()
                .SetValidator(new CoordinateValidator());
        }
    }
}