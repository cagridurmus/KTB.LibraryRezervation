using KTB.LibraryRezervation.Core.DTOs.Seat;

namespace KTB.LibraryRezervation.Core.DTOs.Desk
{
    public class GetDeskDto: BaseDto
	{
		public int LibraryHallId { get; set; }

		public int DeskNo { get; set; }

		public int Capacity { get; set; }

        public List<GetSeatDto>? Seats { get; set; } = new List<GetSeatDto>();



    }
}

