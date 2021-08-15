using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class CreateRoverCommandValidator : AbstractValidator<CreateRoverCommand>
    {
        public CreateRoverCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotNull()
                .NotEmpty();
        }
    }
}