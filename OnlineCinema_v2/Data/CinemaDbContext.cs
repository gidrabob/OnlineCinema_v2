using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
