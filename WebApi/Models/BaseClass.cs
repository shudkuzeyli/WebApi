using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models
{
	public class BaseClass
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[DefaultValue(0)]
		public int OlusturanKullaniciId { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		[StringLength(50)]
		[DisplayName("Oluşturan Kullanıcı")]
		public string OlusturanKullanici { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		[DisplayName("Oluşturma Tarihi")]
		public DateTime OlusturmaTarihi { get; set; }

		[DefaultValue(0)]
		public int GuncelleyenKullaniciId { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		[StringLength(50)]
		[DisplayName("Güncelleyen Kullanıcı")]
		public string GuncelleyenKullanici { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		[DisplayName("Güncelleme Tarihi")]
		public DateTime GuncellemeTarihi { get; set; }

		[ScaffoldColumn(false)]
		[DisplayName("Silinme Durumu")]
		public bool Silindi { get; set; }

		[DisplayName("Aktif Durumu")]
		[DefaultValue(true)]
		public bool Aktif { get; set; }

		[DisplayName("Durum")]
		public string IcActiveString => Aktif ? "Aktif" : "Pasif";
	}
}
