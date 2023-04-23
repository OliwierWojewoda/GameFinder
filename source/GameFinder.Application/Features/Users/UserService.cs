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
    public class UserService
    {
        private readonly IDbContext _context;
        public UserService(IDbContext context)
        {
            _context = context;
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

