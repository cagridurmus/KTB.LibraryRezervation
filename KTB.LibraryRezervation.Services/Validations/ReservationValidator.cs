using System;
using FluentValidation;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Services.Validations
{
	public class ReservationValidator : AbstractValidator<AddReservationDto>
    {
		public ReservationValidator()
		{
			RuleFor(x => x.SeatId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("{PropertyName} must be greater required");
            RuleFor(x => x.EndTime).NotEmpty().WithMessage("{PropertyName} must be greater required");
        }
	}
}

