using Microsoft.AspNetCore.Mvc;
using OnlineCinema_v2.Repositories.Interfaces;
using OnlineCinema_v2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCinema_v2.Repositories;
using OnlineCinema_v2.ViewModels;

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
		public async Task<IActionResult> Edit(int id)
		{
			return View(await _directorRepository.GetDirector(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Director director)
		{
			if (ModelState.IsValid)
			{
				await _directorRepository.EditDirector(director);				
			}
			return View(director);
		}
        public async Task<IActionResult> Create()
        {
            return View(await _directorRepository.GetAllDirectors());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                var newDirector = new Director
                {
                    Name = director.Name,
					BirthDate = director.BirthDate,
                };
                _directorRepository.AddDirector(newDirector);
                return RedirectToAction("Index", "Home");
            }

            return View(director);
        }
    }
}
