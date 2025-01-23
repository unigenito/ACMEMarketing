using FluentValidation;
using Application.Features.Visitors.Command;

namespace Application.Validators
{
    public class UpdateVisitorCommandValidator : AbstractValidator<UpdateVisitorCommand>
    {
        public UpdateVisitorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");
        }
    }
}