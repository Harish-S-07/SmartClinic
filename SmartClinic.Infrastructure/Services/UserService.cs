using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models.User;
using SmartClinic.Infrastructure.Data;

namespace SmartClinic.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly SmartClinicDbContext? _context;
        public UserService(SmartClinicDbContext context)
        {
             _context = context;
        }
        public Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = _context!.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Role = u.Role
            }).ToList();
            return Task.FromResult(users);
        }
    }
}
