using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using GameFinder.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Users.Commands
{
    public record LoginCommand(LoginUserDto user) : IRequest<User>;
    public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User loggedUser = await _userRepository.GetUserByEmail(request.user.Email)
            ?? throw new Exception("No user with this email");
            if (!VerifyPasswordHash(request.user.Password, loggedUser.PasswordHash, loggedUser.PasswordSalt))
            {
                throw new Exception("Wrong Password");
            }
            await _userRepository.Login(loggedUser);
            return loggedUser;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}