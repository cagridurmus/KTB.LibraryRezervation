using System;
namespace KTB.LibraryRezervation.Core.DTOs.LibraryHall
{
	public class GetLibraryHallDto: BaseDto
	{

        public string Name { get; set; }

        public int DeskCapacity { get; set; }

    }
}

