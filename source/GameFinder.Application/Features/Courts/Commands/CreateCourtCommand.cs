using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Courts.Commands
{
    public record CreateCourtCommand(int city_Id) : IRequest;
 
}
