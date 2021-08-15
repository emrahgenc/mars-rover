using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class MoveRoverCommanddValidator : AbstractValidator<MoveRoverCommand>
    {
        public MoveRoverCommanddValidator()
        {
            RuleFor(p => p.RoverId)
                .NotEmpty();
        }
    }
}