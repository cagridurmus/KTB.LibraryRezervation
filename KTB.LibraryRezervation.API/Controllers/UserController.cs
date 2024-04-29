using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Register;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KTB.LibraryRezervation.API.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            var result = await _service.CreateUserAsync(user);
            return CreatedActionResult(CustomResponseDto<bool>.Success(200, result));
        }
    }
}

