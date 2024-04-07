using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Data.Configuration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();

            builder.HasMany(x => x.Films)
                .WithOne(x => x.Director)
                .HasForeignKey(x => x.DirectorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

// migration part: 
// In Visual Studio, open NuGet Package Manager Console from
// Tools -> NuGet Package Manager -> Package Manager Console and enter the following command
// 1. add-migration Initial
// 2. update-database –verbose