using Dashboard.DataAccess.Entities;
using FluentValidation;

namespace Dashboard.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator() { 
        
                RuleFor(m => m.Title).NotNull().NotEmpty();
                RuleFor(m => m.ReleaseDate).NotNull();
        }
    }
}
