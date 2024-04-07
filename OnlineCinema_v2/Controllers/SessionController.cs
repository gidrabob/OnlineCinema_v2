using Microsoft.AspNetCore.Mvc;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.ViewModels;
using OnlineCinema_v2.Repositories;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Controllers
{
	public class SessionController : Controller
	{
		private readonly ISessionRepository _sessionRepository;

		public SessionController (ISessionRepository sessionRepository)
		{
			_sessionRepository = sessionRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _sessionRepository.GetAllSessions());
		}
		public async Task<IActionResult> Edit(int id)
		{
			return View(await _sessionRepository.GetSession(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Session session)
		{
			if (ModelState.IsValid)
			{
				await _sessionRepository.EditSession(session);
			}
			return View(session);
		}
        public async Task<IActionResult> Create()
        {
            return View(await _sessionRepository.GetAllSessions());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SessionViewModel sessionVM)
        {
                if (ModelState.IsValid)
                {
					var newSession = new Session
					{
						SessionTime = sessionVM.SessionTime,
					};
                _sessionRepository.AddSession(newSession);
                 
                    return RedirectToAction("Index", "Home");
                }

                return View(sessionVM);
        }
    }
}
