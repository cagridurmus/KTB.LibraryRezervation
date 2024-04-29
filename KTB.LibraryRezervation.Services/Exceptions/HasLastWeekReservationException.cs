using System;
namespace KTB.LibraryRezervation.Services.Exceptions
{
	public class HasLastWeekReservationException : Exception
	{
        public HasLastWeekReservationException(string message) : base(message)
        {

        }
    }
}

