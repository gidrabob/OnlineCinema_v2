using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineCinema_v2.Models;

namespace OnlineCinema_v2.Data
{
	public class DbInitializer
	{
		private readonly ModelBuilder _modelBuilder;

		public DbInitializer(ModelBuilder modelBuilder)
		{
			_modelBuilder = modelBuilder;
		}

		public void Seed()
		{
			_modelBuilder.Entity<Director>(x =>
			{
				x.HasData(new Director
				{
					Id = 1,
					Name = "Vasya",
					BirthDate = new DateOnly(1990, 10, 10)
				});
				x.HasData(new Director
				{
					Id = 2,
					Name = "Petya",
					BirthDate = new DateOnly(1991, 11, 11)
				});
				x.HasData(new Director
				{
					Id = 3,
					Name = "Anton",
					BirthDate = new DateOnly(1992, 12, 12)
				});
			});
			//_modelBuilder.Entity<Film>(x =>
			//{
			//	x.HasData(new Film
			//	{
			//		Id = 1,
			//		Name = "Utopia",
			//		Description = "sdsdsadasd",
			//		Director = new Director
			//		{
			//			Id = 4,
			//			Name = "Nikola",
			//			BirthDate = new DateOnly(1985, 10, 6)
			//		}
			//	});
			//});
		}
	}
}
