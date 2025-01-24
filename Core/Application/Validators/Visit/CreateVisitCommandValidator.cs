using FluentValidation;
using Application.Features.Visits.Commands;

namespace Application.Validators.Visit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {
        public CreateVisitCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer is required.");

            RuleFor(x => x.VisitorId)
                .NotEmpty().WithMessage("Visitor is required.");

            RuleFor(x => x.VisitDate)
                .NotEmpty().WithMessage("Visit date is required.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Visit date cannot be in the past.");

            RuleFor(x => x.Purpose)
                .NotEmpty().WithMessage("Purpose is required.")
                .MaximumLength(200).WithMessage("Purpose must not exceed 200 characters.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Notes must not exceed 500 characters.");
        }
    }
}