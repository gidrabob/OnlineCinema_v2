using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Data;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public DirectorRepository(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }
        public async Task<IEnumerable<Director>> GetAllDirectors(CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Directors.ToListAsync(cancellationToken) ?? [];
        }
        public async Task<Director> GetDirector(int directorId, CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Directors
                .FirstOrDefaultAsync(x => x.Id == directorId, cancellationToken) ?? throw new Exception("Not Found!");
        }
        public async Task AddDirector(Director director, CancellationToken cancellationToken = default)
        {            
                _cinemaDbContext.Add(director);

            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task EditDirector(Director director, CancellationToken cancellationToken)
        {
            var existingDirector = await _cinemaDbContext.Directors
                .FirstOrDefaultAsync(x => x.Id == director.Id, cancellationToken);
            
            if (existingDirector != null) 
            {
                existingDirector.Name = director.Name;
                existingDirector.BirthDate = director.BirthDate;
            }
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAllDirectors(CancellationToken cancellationToken)
        {
            await _cinemaDbContext.Directors.ExecuteDeleteAsync(cancellationToken);
        }
        public async Task DeleteDirector(int directorId, CancellationToken cancellationToken)
        {
            var existingDirector = await _cinemaDbContext.Directors
                .FirstOrDefaultAsync(x => x.Id == directorId, cancellationToken);
            
            if (existingDirector != null) 
            {
                _cinemaDbContext.Directors.Remove(existingDirector);
                await _cinemaDbContext.SaveChangesAsync();
            }
        }
    }
}