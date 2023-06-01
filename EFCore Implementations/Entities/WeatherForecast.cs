using EFCore_Implementations.Interfaces;

namespace EFCore_Implementations.Entities
{
    public class WeatherForecast : IKeyedModel
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; } = Random.Shared.Next(-20, 55);

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }


        public int? CityId { get; set; }
        public City? City { get; set; } = new();
    }
}