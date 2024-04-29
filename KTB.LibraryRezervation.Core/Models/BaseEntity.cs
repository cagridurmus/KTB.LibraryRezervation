using System;
namespace KTB.LibraryRezervation.Core.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}

