using System.Collections.Generic;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Repositories.Interfaces
{
    public interface IFilmGenreRepository
	{
        Task<IEnumerable<FilmGenre>> GetAllFilmGenres(CancellationToken cancellationToken = default);

        Task<FilmGenre> GetFilmGenre(int filmGenreId, CancellationToken cancellationToken = default);

        Task AddFilmGenre(FilmGenre filmGenre, CancellationToken cancellationToken = default);

        Task EditFilmGenre(FilmGenre filmGenreId, CancellationToken cancellationToken = default);

        Task DeleteFilmGenre(int filmGenreId, CancellationToken cancellationToken = default);
    }
}
