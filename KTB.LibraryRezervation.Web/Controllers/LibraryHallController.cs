using KTB.LibraryRezervation.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace KTB.LibraryRezervation.Web.Controllers
{
    public class LibraryHallController : Controller
    {
        private readonly LibraryHallApiService _libraryHallService;

        public LibraryHallController(LibraryHallApiService libraryHallService)
        {
            _libraryHallService = libraryHallService;
        }

        public async Task<IActionResult> Index()
        {
            var libraries = await _libraryHallService.GetAllHallAsync();
            return View(libraries);
        }
    }
}

