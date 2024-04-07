using System.Collections.Generic;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllDirectors(CancellationToken cancellationToken = default);

        Task<Director> GetDirector(int directorId, CancellationToken cancellationToken = default);

        Task AddDirector(Director director, CancellationToken cancellationToken = default);

        Task EditDirector(Director director, CancellationToken cancellationToken = default);

        Task DeleteDirector(int directorId, CancellationToken cancellationToken = default);

        Task DeleteAllDirectors(CancellationToken cancellationToken = default);
    }
}
