using GameFinder.Application.Data;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.GameDetails.Commands
{
    public record AddUserToGameCommand(NewGameDetailsDto newGameDetailsDto) : IRequest<int>;
    public class AddUserToGameCommandHandler : IRequestHandler<AddUserToGameCommand, int>
    {
        private readonly IDbContext _dbContext;

        public AddUserToGameCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddUserToGameCommand request, CancellationToken cancellationToken)
        {
            var newGameDetails = new Domain.Entities.GameDetails(
                request.newGameDetailsDto.GameId,
                request.newGameDetailsDto.UserId);

            await _dbContext.Game_Details.AddAsync(newGameDetails);
            await _dbContext.SaveChangesAsync();
            return newGameDetails.GameDetailsId;
        }
    }
}
