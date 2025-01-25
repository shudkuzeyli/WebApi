using FluentValidation;
using WebApi.Models;
namespace WebApi.Validators
{
	public class FilmValidator : AbstractValidator<Film>
	{
		public FilmValidator()
		{
			RuleFor(t => t.Yonetmen)
				.NotEmpty().WithMessage("Yönetmen adı boş geçilemez")
				.MinimumLength(3).WithMessage("Yönetmen adı en az 3 karakter olamalı")
				.MaximumLength(50);

			RuleFor(t => t.FilmAdi)
				.NotEmpty().WithMessage("Film adı boş geçilemez");

			RuleFor(t => t.Yil)
				.InclusiveBetween(1900, DateTime.Now.Year)
				.WithMessage($"Yıl 1900 ile {DateTime.Now.Year} arasında olmalı.");
		}
	}
}
