using EFCoreDemo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public JobRecruitmentContext Context { get; }

    public WeatherForecastController(JobRecruitmentContext context)
    {
        Context = context;
    }

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
    public Job Get()
    {
        // Get Data
        // using JobRecruitmentContext context = new JobRecruitmentContext();
        // better - 依赖注入 in `Program.cs`
        var context = Context;
        var job = context.Jobs.FirstOrDefault(m => m.Id == 1);


        job.JobName = ".Net6 高阶全栈架构师";
        // context.Update(job);
        // // Entity tracking, open by default, consuming performance
        // how to close locally?
        job = context.Jobs.AsNoTracking().FirstOrDefault(m => m.Id == 1);

        var city = context.Cities.FirstOrDefault(m => m.Id == 1);
        city.CityName = "Suzhou2";

        // how to close in the lifetime of `context` (in this method)
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        context.SaveChanges();
        return job;
    }
}