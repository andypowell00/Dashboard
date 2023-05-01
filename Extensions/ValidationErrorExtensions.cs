using FluentValidation.Results;

namespace Dashboard.Extensions
{
    public static class ValidationErrorExtensions
    {
        public static string GetErrors(this List<ValidationFailure> errors)
        {

            var errorMessages = "";
            errors.ForEach(error => errorMessages += error.ErrorMessage + " ");

            return errorMessages;
        }
    }
}
