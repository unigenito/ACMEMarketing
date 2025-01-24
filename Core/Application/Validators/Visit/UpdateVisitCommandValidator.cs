using FluentValidation;
using Application.Features.Visits.Commands;

namespace Application.Validators
{
    public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
    {
        public UpdateVisitCommandValidator()
        {
            RuleFor(x => x.VisitId)
                .NotEmpty().WithMessage("Visit ID is required.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Visit date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Visit date cannot be in the future.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Notes must not exceed 500 characters.");

            RuleFor(x => x.Purpose)
                .NotEmpty().WithMessage("Purpose is required.")
                .MaximumLength(200).WithMessage("Purpose must not exceed 200 characters.");
        }
    }
}