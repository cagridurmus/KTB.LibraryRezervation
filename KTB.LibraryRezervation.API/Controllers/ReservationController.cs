using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KTB.LibraryRezervation.API.Controllers
{
    public class ReservationController : CustomBaseController
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRezervation(AddReservationDto dto)
        {
            var isCreated = await _service.CreateReservation(dto);
            return CreatedActionResult(CustomResponseDto<bool>.Success(201, isCreated));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetActiveReservation(string email)
        {
            var reservations = await _service.GetUserReservationsAsync(email);
            return CreatedActionResult(CustomResponseDto<List<GetReservationDto>>.Success(200, reservations));
        }
    }
}

