using FluentValidation;
using GameFinder.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Cities.Commands
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator(IDbContext dbContext)
        {
            RuleFor(c => c.name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Name should have maxium of 20 characters")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = dbContext.City.FirstOrDefault(x => x.Name == value);
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique name for city");
                    }
                });
        }
    }
}
