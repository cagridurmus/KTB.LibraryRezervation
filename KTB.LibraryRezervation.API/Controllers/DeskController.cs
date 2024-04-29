using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Desk;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KTB.LibraryRezervation.API.Controllers
{
    public class DeskController : CustomBaseController
    {
        private readonly IDeskService _service;
        private readonly IMapper _mapper;

        public DeskController(IMapper mapper, IDeskService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesk(int hallId, DateTime startTime, DateTime endTime)
        {
            var deskDtos = await _service.GetDesksWithSeatAsync(hallId, startTime, endTime);
            return CreatedActionResult(CustomResponseDto<List<GetDeskDto>>.Success(200, deskDtos));
        }


    }
}

