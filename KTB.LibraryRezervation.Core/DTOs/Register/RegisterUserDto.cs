using System;
namespace KTB.LibraryRezervation.Core.DTOs.Register
{
	public class RegisterUserDto
    {
        public string NameSurname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}

