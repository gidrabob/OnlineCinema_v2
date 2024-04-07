using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Data;
using OnlineCinema_v2.Models;
using OnlineCinema_v2.Repositories.Interfaces;

namespace OnlineCinema_v2.Repositories
{
    public class FilmGenreRepository : IFilmGenreRepository
	{
        private readonly CinemaDbContext _cinemaDbContext;
        public FilmGenreRepository (CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<FilmGenre>> GetAllFilmGenres(CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.FilmGenres.ToListAsync(cancellationToken) ?? [];
        }
        public async Task<FilmGenre> GetFilmGenre(int filmGenres, CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.FilmGenres
                .FirstOrDefaultAsync(x => x.Id == filmGenres, cancellationToken) ?? throw new Exception("Not Found!");
        }
        public async Task AddFilmGenre(FilmGenre filmGenre, CancellationToken cancellationToken = default)
        {            
                _cinemaDbContext.Add(filmGenre);
         
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task EditFilmGenre(FilmGenre filmGenres, CancellationToken cancellationToken)
        {
            var existingFilmGenre = await _cinemaDbContext.FilmGenres
                .FirstOrDefaultAsync(x => x.Id == filmGenres.Id, cancellationToken);

            if (existingFilmGenre != null)
            {
                existingFilmGenre.Name = filmGenres.Name;
                existingFilmGenre.Description = filmGenres.Description;
            }            
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);            
        }
        public async Task DeleteFilmGenre(int directorId, CancellationToken cancellationToken)
        {
            var existingFilmGenre = await _cinemaDbContext.FilmGenres
                .FirstOrDefaultAsync(x => x.Id == directorId, cancellationToken);
            
            if (existingFilmGenre != null) 
            {
                _cinemaDbContext.FilmGenres.Remove(existingFilmGenre);
                await _cinemaDbContext.SaveChangesAsync(cancellationToken);
            }            
        }
    }
}