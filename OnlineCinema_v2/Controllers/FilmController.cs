using Microsoft.AspNetCore.Mvc;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Controllers
{
	public class FilmController : Controller
	{
		private readonly IFilmRepository _filmRepository;

		public FilmController(IFilmRepository filmRepository)
		{
            _filmRepository = filmRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _filmRepository.GetAllFilms());
		}
		public async Task<IActionResult> Create()
		{
			return View(await _filmRepository.GetAllFilms());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Film film)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var newFilm = new Film
					{
						Name = film.Name,
						Description = film.Description,
						Director = film.Director,
						Sessions = film.Sessions,
					};
					_filmRepository.AddFilm(newFilm);

					return RedirectToAction("Index");
				}

				return View(ModelState);
			}
			catch (Exception)
			{
				return RedirectToAction("Index");
			}
		}
	}
}
