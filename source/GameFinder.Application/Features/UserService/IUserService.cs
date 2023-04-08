using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.UserService
{
    public interface IUserService
    {
        Task<List<User>> Register(NewUserDto newUser);
    }
}
