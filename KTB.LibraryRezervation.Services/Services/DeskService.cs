using System;
using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs.Desk;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Repositories;
using KTB.LibraryRezervation.Core.Services;
using KTB.LibraryRezervation.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace KTB.LibraryRezervation.Services.Services
{
    public class DeskService : Service<Desk>, IDeskService
    {
        private readonly IGenericRepository<Desk> _repository;
        private readonly IMapper _mapper;

        public DeskService(IGenericRepository<Desk> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetDeskDto>> GetDesksWithSeatAsync(int hallId, DateTime startTime, DateTime endTime)
        {
            var now = DateTime.Now;
            var nowPlus = DateTime.Now.AddHours(3);
            var desks = await Where(dsk => dsk.LibraryHallId == hallId)
                .Include(dsk => dsk.Seats)
                .ThenInclude(st => st.Reservations)
                .ToListAsync();
            var deskDtos = _mapper.Map<List<GetDeskDto>>(desks);
            deskDtos.ForEach(dsk => dsk.Seats.ForEach(st => {
                var x = st.Reservations.Where(rzv => rzv.StartTime <= now && rzv.EndTime >= now);
                st.IsReserved = st.Reservations.Where(rzv => rzv.StartTime <= startTime && rzv.EndTime >= endTime).Any();
            }));
            return deskDtos;
        }
    }
}

