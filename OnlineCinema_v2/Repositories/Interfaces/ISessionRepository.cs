using System.Collections.Generic;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllSessions(CancellationToken cancellationToken = default);

        Task<Session> GetSession(int sessionId, CancellationToken cancellationToken = default);

        Task AddSession(Session session, CancellationToken cancellationToken = default);

        Task EditSession(Session session, CancellationToken cancellationToken = default);

        Task DeleteSession(int sessionId, CancellationToken cancellationToken = default);

        Task DeleteAllSessions(CancellationToken cancellationToken = default);
    }
}
