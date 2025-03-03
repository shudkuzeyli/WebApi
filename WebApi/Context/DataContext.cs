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

		#region Overrides
		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			OnBeforeSaving();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
		public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			OnBeforeSaving();
			var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
			return result;
		}
		#endregion

		#region Methods
		private void OnBeforeSaving()
		{
			//savechange ile sonlandırılan bütün modeller vertibanaına gitmeden önce buraya gelmek zorunda
			var entries = ChangeTracker.Entries();

			foreach (var entry in entries)
			{
				if (entry.Entity is BaseClass tracable)
				{
					var tarih = DateTime.Now;

					switch (entry.State)
					{
						case EntityState.Modified:
							tracable.GuncellemeTarihi = tarih;
							tracable.GuncelleyenKullanici = "güncllyn kullanıcı";
							tracable.GuncelleyenKullaniciId = 1;
							break;
						case EntityState.Added:
							tracable.OlusturmaTarihi = tarih;
							tracable.OlusturanKullanici = "oluşturan kullanıcı";
							tracable.OlusturanKullaniciId = 1;

							tracable.Aktif = true;
							tracable.Silindi = false;
							break;
					}
				}

				//_datacontext in getirdiği modellerdeki sadece türü string olan property leri alır.
				var proprtyValus = entry.CurrentValues.Properties.Where(p => p.ClrType == typeof(string));


				//veritabanına gideck tüm modllrdki string türündeki değişknlr kontrol ediyolıyor.
				foreach (var prop in proprtyValus)
				{
					string stringValue = entry.CurrentValues[prop.Name].ToString();

					if (string.IsNullOrWhiteSpace(stringValue))
						continue;

					entry.CurrentValues[prop.Name] = stringValue.Trim();
				}
			}
		}
		#endregion
	}
}
