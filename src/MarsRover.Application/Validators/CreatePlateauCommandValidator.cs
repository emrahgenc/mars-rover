using FluentValidation;
using MarsRover.Application.Commands;

namespace MarsRover.Application.Validators
{
    public class CreatePlateauCommandValidator : AbstractValidator<CreatePlateauCommand>
    {
        public CreatePlateauCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Height)
                .GreaterThan(0);

            RuleFor(p => p.Width)
                .GreaterThan(0);
        }
    }
}
