using System;
using AutoMapper;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Repositories;
using KTB.LibraryRezervation.Core.Services;
using KTB.LibraryRezervation.Core.UnitOfWorks;

namespace KTB.LibraryRezervation.Services.Services
{
    public class SeatService : Service<Seat>, ISeatService
    {
        private readonly IGenericRepository<Seat> _seatRepository;
        private readonly IMapper _mapper;
        public SeatService(IGenericRepository<Seat> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _seatRepository = repository;
            _mapper = mapper;
        }

        

    }
}

