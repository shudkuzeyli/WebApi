using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
	public class Yonetmen
	{
	[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		public string YonetmenAdi { get; set; }
	}
}
