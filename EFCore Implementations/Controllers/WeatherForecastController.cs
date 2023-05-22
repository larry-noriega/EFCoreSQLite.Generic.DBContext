using EFCore_Implementations.Context;
using EFCore_Implementations.Entities;
using EFCore_Implementations.Interfaces;
using EFCore_Implementations.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SQLitePCL;

namespace EFCore_Implementations.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IGenericRepository<WeatherForecast> _genericRepository;
		private readonly IOptions<SQLiteSettings>? _options;

		private static readonly string[] Summaries = new[]
		{ "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

		private static readonly string[] Cities = new[]
		{ "El Cadot","Barrajicá","Ibagua","Archiranda","Apasinéry","Tonnélor","Isherneru","Tumebo","Cosi","Cornemutu","Tinacara","El Limche" };

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<SQLiteSettings>? options)
		{
			_logger = logger;
			_options = options;
			_genericRepository = new GenericRepository<WeatherForecast>(_options);
		}

		[HttpGet("generate-forecasts")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)],
				City = new()
				{
					Name = Cities[Random.Shared.Next(Cities.Length)]
				}
			})
			.ToArray();
		}

		[HttpGet("get-weathers")]
		public async Task<IEnumerable<WeatherForecast?>> List()
		{
			return await _genericRepository.List();
		}

		[HttpGet(Name = "Get")]
		public async Task<ActionResult> Get(int id)
		{
			var forecast = await _genericRepository.Get(id);

			if (forecast is null) return NoContent();

			return Ok(forecast);
		}

		[HttpPost]
		public async Task<ActionResult> Insert(WeatherForecast forecast)
		{
			if (forecast is null) throw new ArgumentNullException("No data to record",nameof(WeatherForecast));

			var response = await _genericRepository.Insert(forecast);

			return CreatedAtRoute(nameof(Get), new { forecast.Id }, forecast);
		}

		[HttpPut]
		public async Task<ActionResult> Update([FromBody] WeatherForecast forecast)
		{
			var response = await _genericRepository.Update(forecast);

			if (response is null) return NotFound();

			return Ok(response);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await _genericRepository.Delete(id);

			if (response is null) return NotFound();

			return NoContent();
		}
	}
}