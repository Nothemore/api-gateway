using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.WeatherForecastContext.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/weather-forecast")]
[ApiVersion(1.0)]
public class WeatherForecastController1V : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController1V> _logger;

    public WeatherForecastController1V(ILogger<WeatherForecastController1V> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ApiVersion( 1.0, Deprecated = true )]
    [MapToApiVersion(1.0)]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}