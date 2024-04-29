using FluentValidation;
using KTB.LibraryRezervation.Core.DTOs.Desk;

namespace KTB.LibraryRezervation.Services.Validations
{
    public class DeskValidator : AbstractValidator<AddDeskDto>
    {
		public DeskValidator()
		{
			RuleFor(x => x.DeskNo).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Capacity).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.LibraryHallId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
	}
}

