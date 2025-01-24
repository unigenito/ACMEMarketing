using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException: Exception
{
    public ValidationException(): base("There are values invalids.")
    {
        Errors = new List<String>();
    }

    public List<string> Errors { get; private set; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}