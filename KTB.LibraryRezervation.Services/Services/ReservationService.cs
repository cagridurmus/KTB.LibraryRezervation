using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.Hubs;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Repositories;
using KTB.LibraryRezervation.Core.Services;
using KTB.LibraryRezervation.Core.UnitOfWorks;
using KTB.LibraryRezervation.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KTB.LibraryRezervation.Services.Services
{
    public class ReservationService: Service<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatHubService _hubService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReservationService(IGenericRepository<Reservation> repository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository, IMapper mapper, IUserService userService, ISeatHubService hubService) : base(repository, unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _userService = userService;
            _hubService = hubService;
        }

        public async Task<bool> CreateReservation(AddReservationDto reservationDto)
        {
            var appUser = await _userService.FindByUserAsync(reservationDto.Email);

            var reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.AppUser = appUser;
            var checkReservation = await _reservationRepository.HasLastWeekReservation(appUser, reservationDto.StartTime);
            if (checkReservation)
            {
                throw new HasLastWeekReservationException("Bu hafta içerisinde 2 tane kaydınız bulunmaktadır");
            }

            var newReservation = await AddAsync(reservation);
            if (newReservation == null)
            {
                return false;
            }
            await _hubService.SeatRezervMessageAsync(1, reservationDto.SeatId, "Koltuk Rezerv edildi");
            return true;
        }

        public async Task<List<GetReservationDto>> GetUserReservationsAsync(string email)
        {
            var now = DateTime.Now;
            var appUser = await _userService.FindByUserAsync(email);

            var reservations = await Where( rzv => rzv.AppUser == appUser).ToListAsync();
            var reservationDtos = _mapper.Map<List<GetReservationDto>>(reservations);

            foreach (var reservation in reservationDtos)
            {
                reservation.isActive = reservations.Any(rzv => rzv.StartTime <= now && reservation.EndTime >= now);
            }


            return reservationDtos;
        }
    }
}

