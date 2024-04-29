using System;
using KTB.LibraryRezervation.Core.DTOs.Login;

namespace KTB.LibraryRezervation.Core.Services
{
	public interface IAuthService
	{
        public Task<bool> LoginAsync(LoginUserDto login);
        public Task LogoutAsync();
    }
}

