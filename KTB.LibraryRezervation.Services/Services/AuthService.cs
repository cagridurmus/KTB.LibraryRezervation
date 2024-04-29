using System;
using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs.Login;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace KTB.LibraryRezervation.Services.Services
{
	public class AuthService: IAuthService
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(SignInManager<AppUser> signInManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> LoginAsync(LoginUserDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if(user == null)
            {
                return false;
            }
            //var appUser = _mapper.Map<AppUser>(login);
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

