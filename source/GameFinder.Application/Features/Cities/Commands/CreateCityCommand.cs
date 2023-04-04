using GameFinder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Cities.Commands
{
    public record CreateCityCommand(string name) : IRequest<int>;
}
