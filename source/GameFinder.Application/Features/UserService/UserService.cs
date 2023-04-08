using GameFinder.Application.Data;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.UserService
{
    public class UserService : IUserService
    {
        private readonly IDbContext _context;
        public UserService(IDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> Register(NewUserDto newUser)
        {
            if(_context.User.Any(x => x.Email == newUser.Email))
            {
                throw new Exception("User exists"); 
            }
            CreatePasswordHash(newUser.Password,out byte[] passwordHash,out byte[] passwordSalt);
            User user = new User()
            {
                Name = newUser.Name,
                Surname = newUser.Surname,
                Birthday = newUser.Birthday,
                Email = newUser.Email,
                PasswordHash = passwordHash,
                Phone = newUser.Phone,
                RoleId = newUser.RoleId
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return await _context.User.ToListAsync();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
