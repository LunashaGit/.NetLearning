using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("{id}", Name = "GetWeatherForecastById")]

    public WeatherForecast GetById(int id)
    {
        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

    [HttpPost(Name = "CreateWeatherForecast")]

    public IActionResult Create(WeatherForecast weatherForecast)
    {
        return CreatedAtRoute("GetWeatherForecastById", new { id = 1 }, weatherForecast);
    }

    [HttpPut("{id}", Name = "UpdateWeatherForecast")]

    public IActionResult Update(int id, WeatherForecast weatherForecast)
    {
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteWeatherForecast")]

    public IActionResult Delete(int id)
    {
        return NoContent();
    }
    
}
