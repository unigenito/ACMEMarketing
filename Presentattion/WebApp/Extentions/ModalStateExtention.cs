using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Extentions;

public static class ModalStateExtention
{
    public static void AddToModelState(this ModelStateDictionary modelState, IEnumerable<ValidationFailure> validationFailures) 
    {
        foreach (var error in validationFailures) 
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}