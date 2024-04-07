using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Data;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public SessionRepository(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<Session>> GetAllSessions(CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Sessions.ToListAsync(cancellationToken)??[];
        }
        public async Task<Session> GetSession(int session, CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Sessions
                .FirstOrDefaultAsync(x => x.Id == session, cancellationToken) ?? throw new Exception("Not Found!");
        }
        public async Task AddSession(Session session, CancellationToken cancellationToken = default)
        {            
                _cinemaDbContext.Add(session);
         
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task EditSession(Session session, CancellationToken cancellationToken)
        {
            var existingSession = await _cinemaDbContext.Sessions
                .FirstOrDefaultAsync(x => x.Id == session.Id, cancellationToken);

            if (existingSession != null)
            {
                existingSession.SessionTime = session.SessionTime;
            }            
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);            
        }
        public async Task DeleteSession(int session, CancellationToken cancellationToken)
        {
            var existingSession = await _cinemaDbContext.Sessions
                .FirstOrDefaultAsync(x => x.Id == session, cancellationToken);
            
            if (existingSession != null) 
            {
                _cinemaDbContext.Sessions.Remove(existingSession);
                await _cinemaDbContext.SaveChangesAsync(cancellationToken);
            }            
        }
        public async Task DeleteAllSessions(CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.Sessions.ExecuteDeleteAsync(cancellationToken);
        }
    }
}