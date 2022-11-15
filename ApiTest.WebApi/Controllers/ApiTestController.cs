using Microsoft.AspNetCore.Mvc;
using ApiTest.DataModule;

namespace ApiTest.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiTestController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    private readonly ILogger<ApiTestController> _logger;
    private readonly DataModuleService _dataModule;

    public ApiTestController(ILogger<ApiTestController> logger, DataModuleService dataModule)
    {
        _logger = logger;
        _dataModule = dataModule;
    }

    [HttpGet]
    public string Test()
    {
        return _dataModule.Test();
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
