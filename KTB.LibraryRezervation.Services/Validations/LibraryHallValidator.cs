using FluentValidation;
using KTB.LibraryRezervation.Core.DTOs.LibraryHall;

namespace KTB.LibraryRezervation.Services.Validations
{
    public class LibraryHallValidator: AbstractValidator<AddLibraryHallDto>
    {
		public LibraryHallValidator()
		{
			RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DeskCapacity).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
	}
}

