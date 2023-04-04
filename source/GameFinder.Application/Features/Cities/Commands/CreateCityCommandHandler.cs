using GameFinder.Application.Data;
using GameFinder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Cities.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IDbContext _dbContext;

        public CreateCityCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var newCity = City.New(request.name);

            var city = await _dbContext.City.AddAsync(newCity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return city.Entity.CityId;

        }
    }
}
