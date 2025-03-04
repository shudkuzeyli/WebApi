using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmController : ControllerBase
	{
		private readonly DataContext _dataContext;
		public FilmController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}


		[HttpGet]
		public async Task<ActionResult<List<Film>>> Get()
		{
			var data = await _dataContext.Film.ToListAsync();
			return Ok(data);
		}

		[HttpPost]
		public async Task<ActionResult> AddFilm(Film film)
		{
			if (film == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid == false)
			{
				return BadRequest(ModelState);
			}

			try
			{
				_dataContext.Film.Add(film);
				await _dataContext.SaveChangesAsync();
			}
			catch (Exception e)
			{
			}

			return Ok("Başarılı");
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> EditFilm(Film film, int? id)
		{
			if (film == null)
			{
				return NotFound($"{id} li veri bulunamadı.");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id is null)
			{
				return NotFound();
			}

			try
			{
				//_dataContext.Film.Add(film);

				var dbdata = await _dataContext.Film.Where(t => t.Id == film.Id).FirstOrDefaultAsync();
				if (dbdata == null)
				{
					return NotFound($"{id} DB'de yok");
				}

				dbdata.FilmAdi = film.FilmAdi;
				dbdata.Yonetmen = film.Yonetmen;
				dbdata.Tur = film.Tur;
				dbdata.TurId = film.TurId;
				dbdata.Yil = film.Yil;

				_dataContext.Update(dbdata);
				await _dataContext.SaveChangesAsync();
			}
			catch (Exception h)
			{
			}

			return Ok("Başarılı");
		}

		//[HttpPut()]
		//public async Task<ActionResult> EditFilm(Film film)
		//{
		//	if (film == null)
		//	{
		//		return NotFound();
		//	}
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	try
		//	{
		//		//_dataContext.Film.Add(film);

		//		var dbdata = await _dataContext.Film.Where(t => t.Id == film.Id).FirstOrDefaultAsync();
		//		if (dbdata == null)
		//		{
		//			return NotFound();
		//		}

		//		dbdata.FilmAdi = film.FilmAdi;
		//		dbdata.Yonetmen = film.Yonetmen;
		//		dbdata.Tur = film.Tur;
		//		dbdata.TurId = film.TurId;
		//		dbdata.Yil = film.Yil;

		//		_dataContext.Update(dbdata);
		//		await _dataContext.SaveChangesAsync();
		//	}
		//	catch (Exception h)
		//	{
		//	}

		//	return Ok("Başarılı");
		//}

		[HttpGet("{id}")]
		public async Task<ActionResult<Film>> GetById(int? id)
		{
			if (id == null)
			{
				return NoContent();
			}

			var data = await _dataContext.Film.Where(i => i.Id == id).FirstOrDefaultAsync();

			if (data is null)
			{
				return NoContent();
			}

			return Ok(data);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteFilm(Film film, int? id)
		{
			var dbdata = await _dataContext.Film.Where(i => i.Id == id).FirstOrDefaultAsync();
			if (dbdata == null)
			{
				return NotFound($"{id} DB'de yok");
			}

			_dataContext.Remove(dbdata);
			await _dataContext.SaveChangesAsync();

			return Ok("Başarılı");
		}
	}
}
