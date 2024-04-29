using System;
using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs.Register;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace KTB.LibraryRezervation.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(RegisterUserDto user)
        {
            var appUser = _mapper.Map<AppUser>(user);
            appUser.Id = Guid.NewGuid();
            var result = await _userManager.CreateAsync(appUser,user.Password);

            return result.Succeeded;
        }

        public async Task<AppUser> FindByUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}

