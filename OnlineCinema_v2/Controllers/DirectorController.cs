using Microsoft.AspNetCore.Mvc;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Controllers
{
	public class DirectorController : Controller
	{
		private readonly IDirectorRepository _directorRepository;

		public DirectorController(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _directorRepository.GetAllDirectors());
		}

	}
}
