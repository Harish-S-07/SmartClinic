using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models.User;
using SmartClinic.Infrastructure.Data;

namespace SmartClinic.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly SmartClinicDbContext _context;
        public UserService(SmartClinicDbContext context)
        {
             _context = context;
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users
             .Select(u => new UserDto
             {
                 Id = u.Id,
                 FullName = u.FullName,
                 Role = u.Role
             })
             .ToListAsync();

            return users;
        }
    }
}
