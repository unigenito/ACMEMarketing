using FluentValidation;
using Application.Features.Visitors.Command;

namespace Application.Validators
{
    public class UpdateVisitorCommandValidator : AbstractValidator<UpdateVisitorCommand>
    {
        public UpdateVisitorCommandValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10,15}$").WithMessage("Phone number must be 10-15 digits.");

                RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(50).WithMessage("Position must not exceed 50 characters.");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department is required.")
                .MaximumLength(50).WithMessage("Department must not exceed 50 characters.");
        }
    }
}