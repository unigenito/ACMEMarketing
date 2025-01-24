using FluentValidation;
using Application.Features.Visitors.Command;

namespace Application.Validators
{
    public class CreateVisitorCommandValidator : AbstractValidator<CreateVisitorCommand>
    {
        public CreateVisitorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");
            
            RuleFor(x => x.Sex)
                .NotEmpty().WithMessage("Sex is required.")
                .MaximumLength(10).WithMessage("Sex must not exceed 10 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Visit date is required.")
                .MaximumLength(50).WithMessage("Visit date must not exceed 50 characters.");
            
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(50).WithMessage("Position must not exceed 50 characters.");
            
            RuleFor(x => x.Identification)
                .NotEmpty().WithMessage("Identification is required.")
                .Matches(@"^[A-Za-z0-9]+$").WithMessage("Identification must be letter or digits.");
        }
    }
}