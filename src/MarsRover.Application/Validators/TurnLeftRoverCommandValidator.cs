using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class TurnLeftRoverCommandValidator : AbstractValidator<TurnLeftRoverCommand>
    {
        public TurnLeftRoverCommandValidator()
        {
            RuleFor(p => p.RoverId)
                .NotEmpty();
        }
    }
}