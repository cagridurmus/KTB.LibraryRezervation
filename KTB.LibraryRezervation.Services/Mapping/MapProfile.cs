using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Desk;
using KTB.LibraryRezervation.Core.DTOs.LibraryHall;
using KTB.LibraryRezervation.Core.DTOs.Login;
using KTB.LibraryRezervation.Core.DTOs.Register;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.DTOs.Seat;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Services.Mapping
{
    public class MapProfile: Profile
	{
		public MapProfile()
		{
			CreateMap<LoginUserDto, AppUser>();
			CreateMap<RegisterUserDto, AppUser>();
            CreateMap<GetLibraryHallDto, LibraryHall>().ReverseMap();
            CreateMap<AddLibraryHallDto, LibraryHall>();
            CreateMap<GetDeskDto, Desk>().ReverseMap();

            CreateMap<GetSeatDto, Seat>().ReverseMap();

            CreateMap<GetReservationDto, Reservation>().ReverseMap();
            CreateMap<AddReservationDto, Reservation>();
        }
	}
}

