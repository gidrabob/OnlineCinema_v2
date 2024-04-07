using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Data;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public FilmRepository(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }
        public async Task<IEnumerable<Film>> GetAllFilms(CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Films.ToListAsync(cancellationToken) ?? [];
        }
        public async Task<Film> GetFilm(int filmId, CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Films
                .Include(x => x.Director)
                .FirstOrDefaultAsync(x => x.Id == filmId, cancellationToken) ?? throw new Exception("Not Found!");
        }
        public async Task AddFilm(Film film, CancellationToken cancellationToken = default)
        {
            var existingFilm = await _cinemaDbContext.Films
                .FirstOrDefaultAsync(x => x.Id == film.Id, cancellationToken);

            _cinemaDbContext.Add(film); 

            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
        public Task EditFilm(int filmId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task DeleteFilm(int filmId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAllFilms(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
