using AutoMapper;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.LibraryHall;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KTB.LibraryRezervation.API.Controllers
{
    public class LibraryHallController : CustomBaseController
    {
        private readonly IService<LibraryHall> _service;

        private readonly IMapper _mapper;

        public LibraryHallController(IService<LibraryHall> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHall()
        {
            var libraries = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<GetLibraryHallDto>>(libraries);
            return CreatedActionResult(CustomResponseDto<List<GetLibraryHallDto>>.Success(200, dtos));
        }
    }
}

