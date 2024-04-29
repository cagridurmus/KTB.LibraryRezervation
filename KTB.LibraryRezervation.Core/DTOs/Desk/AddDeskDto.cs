using System;

namespace KTB.LibraryRezervation.Core.DTOs.Desk
{
	public class AddDeskDto
	{
        public int LibraryHallId { get; set; }

        public int DeskNo { get; set; }

        public int Capacity { get; set; }
    }
}

