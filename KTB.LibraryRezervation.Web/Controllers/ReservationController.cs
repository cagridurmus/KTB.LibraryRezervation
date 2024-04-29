using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Web.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KTB.LibraryRezervation.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationApiService _service;

        public ReservationController(ReservationApiService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Add(AddReservationDto dto)
        {
            var isCreated = await _service.AddReservationAsync(dto);
            return Json(isCreated);
        }

        public async Task<IActionResult> MyReservations(string email)
        {
            var reservation = await _service.GetReservationAsync(email);
            return View(reservation);
        }
    }
}

