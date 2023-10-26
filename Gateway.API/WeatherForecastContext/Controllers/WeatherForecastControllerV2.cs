using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.WeatherForecastContext.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/weather-forecast")]
[ApiVersion(2.0)]
public class WeatherForecastController2V : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController2V> _logger;

    public WeatherForecastController2V(ILogger<WeatherForecastController2V> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
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