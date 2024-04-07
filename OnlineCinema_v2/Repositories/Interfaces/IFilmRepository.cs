using System.Collections.Generic;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFilms(CancellationToken cancellationToken = default);

        Task<Film> GetFilm(int filmId, CancellationToken cancellationToken = default);

        Task AddFilm(Film film, CancellationToken cancellationToken = default);

        Task EditFilm(int filmId, CancellationToken cancellationToken = default);

        Task DeleteFilm(int filmId, CancellationToken cancellationToken = default);

        Task DeleteAllFilms(CancellationToken cancellationToken = default);
    }
}
