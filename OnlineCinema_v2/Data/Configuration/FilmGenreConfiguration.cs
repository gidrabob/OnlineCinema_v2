using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Data.Configuration
{
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.Films)
                .WithMany(x => x.FilmGenres);
        }
    }
}

// migration part: 
// In Visual Studio, open NuGet Package Manager Console from
// Tools -> NuGet Package Manager -> Package Manager Console and enter the following command
// 1. add-migration Initial
// 2. update-database –verbose