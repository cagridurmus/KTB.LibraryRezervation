using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Login;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KTB.LibraryRezervation.API.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            var result = await _authService.LoginAsync(user);
            
            return CreatedActionResult(CustomResponseDto<bool>.Success(200, result));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            return CreatedActionResult(CustomResponseDto<bool>.Success(200, true));
        }
    }
}

