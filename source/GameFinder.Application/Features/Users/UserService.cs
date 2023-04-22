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
                RoleId = newUser.RoleId,
                PasswordSalt = passwordSalt
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return await _context.User.ToListAsync();
        }
        public async Task<User> Login(LoginUserDto user)
        {
            User loggedUser = await _context.User.FirstOrDefaultAsync(x => x.Email == user.Email)
                ?? throw new Exception("No user with this email");

            if (!VerifyPasswordHash(user.Password,loggedUser.PasswordHash,loggedUser.PasswordSalt))
            {
                throw new Exception("Wrong Password");
            }
            return loggedUser;
        }
        public async Task<List<User>> GetAllUsers()
        {
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

