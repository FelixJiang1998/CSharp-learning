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
    // [CtmResourceFilter]
    [TypeFilter(typeof(CtmResourceFilterAttribute))]
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
    // [TypeFilter(typeof(CtmActionFilterAttribute))] // Way 1.
    // Way 2. Need to register the filter in advance in Program.cs
    // 如果使用了ServiceFilter, 那么无论是filter本身还是filter需要注入的参数, 都需要·提前·在容器中注册
    [ServiceFilter(typeof(CtmActionFilterAttribute))]
    public User AddUser(User user)
    {
        return user;
    }
}