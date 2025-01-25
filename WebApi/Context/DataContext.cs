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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Film>()
			.Property(f => f.Id)
			.HasDefaultValueSql("NEXT VALUE FOR FilmSquence");
		}
	}
}
