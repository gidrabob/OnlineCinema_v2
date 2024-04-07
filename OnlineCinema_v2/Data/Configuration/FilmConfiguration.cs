using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Data.Configuration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.DirectorId).IsRequired();
            builder.Property(x => x.FilmGenreId).IsRequired();
            builder.Property(x => x.SessionId).IsRequired();

            builder.HasOne(x => x.Director)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.DirectorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.FilmGenres)
                .WithMany(x => x.Films);

            builder.HasMany(x => x.Sessions)
                .WithMany(x => x.Films);
               
                
                
        }
    }
}

// migration part: 
// In Visual Studio, open NuGet Package Manager Console from
// Tools -> NuGet Package Manager -> Package Manager Console and enter the following command
// 1. add-migration Initial
// 2. update-database –verbose