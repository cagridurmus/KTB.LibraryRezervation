using System;
using KTB.LibraryRezervation.Core.DTOs.Register;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.Services
{
	public interface IUserService
	{
		public Task<bool> CreateUserAsync(RegisterUserDto user);

		public Task<AppUser> FindByUserAsync(string email);

    }
}

