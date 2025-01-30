using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Film> Film { get; set; }
		public DbSet<Yonetmen> Yonetmen { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<Film>()
			//.Property(f => f.Id)
			//.HasDefaultValueSql("NEXT VALUE FOR FilmSquence");

			modelBuilder.Entity<Yonetmen>()
			.Property(y => y.Id)
			.HasDefaultValueSql("NEWID()");
		}
	}
}
