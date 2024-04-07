using Microsoft.AspNetCore.Mvc;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Controllers
{
	public class FilmGenreController : Controller
	{
		private readonly IFilmGenreRepository _filmGenreRepository;

		public FilmGenreController(IFilmGenreRepository filmGenreRepository)
		{
            _filmGenreRepository = filmGenreRepository;

        }

		public async Task<IActionResult> Index()
		{
			return View(await _filmGenreRepository.GetAllFilmGenres());
		}
	}
}
