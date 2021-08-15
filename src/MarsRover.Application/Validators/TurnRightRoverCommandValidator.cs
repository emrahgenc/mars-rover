using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class TurnRightRoverCommandValidator : AbstractValidator<TurnRightRoverCommand>
    {
        public TurnRightRoverCommandValidator()
        {
            RuleFor(p => p.RoverId)
                .NotEmpty();
        }
    }
}