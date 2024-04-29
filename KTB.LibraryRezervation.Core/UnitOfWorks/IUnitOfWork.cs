using System;
namespace KTB.LibraryRezervation.Core.UnitOfWorks
{
	public interface IUnitOfWork
	{
        Task CommitAsync();

        void Commit();
    }
}

