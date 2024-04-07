using Microsoft.AspNetCore.Mvc;
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

	}
}
