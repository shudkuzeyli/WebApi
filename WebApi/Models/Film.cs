using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
	public class Film
	{
		/*
		 Create Squence FilmSquence
		 Sart with 5000
		 increment by 5;
		 */
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FilmAdi { get; set; }

		public string Yonetmen { get; set; }

		//{[Tolga-01.02.2025 tarhinden sonra nunu görüyorsan silebilirsin]}
		public string Tur { get; set; }
		public int? TurId { get; set; }

		public int Yil { get; set; }
	}
}


//--SEQUENCE TABLE SORGULAMA KODU YAZILACAK.