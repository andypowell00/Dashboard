using Dashboard.DataAccess.Entities;
using Dashboard.Extensions;
using FluentValidation;

namespace Dashboard.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            if (validator is not null)
            {
                var entity = context.Arguments.OfType<T>().FirstOrDefault(a => a?.GetType() == typeof(T));
                if (entity is not null)
                {
                    var result = await validator.ValidateAsync(entity);
                    if (!result.IsValid)
                    {
                        var errors = result.Errors.GetErrors();
                        return Results.Problem(errors);
                    }
                }
                else
                {
                    return Results.Problem("Could not find type to validate.");
                }
            }
            return await next(context);
        }
    }


}
