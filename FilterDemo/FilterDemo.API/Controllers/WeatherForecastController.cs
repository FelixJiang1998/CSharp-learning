using FilterDemo.API.Filters;
using FilterDemo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.API.Controllers;

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
    // [CtmActionFilter]
    [CtmAuthorizationFilter]
    [CtmResourceFilter]
    public IEnumerable<WeatherForecast> Get(int userId, string username)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost]
    // [CtmActionFilter(_logger)]
    [TypeFilter(typeof(CtmActionFilterAttribute))] // 1.
    [ServiceFilter(typeof(CtmActionFilterAttribute))]  // 2. Need to register the filter in advance in Program.cs
    public User AddUser(User user)
    {
        return user;
    }
}