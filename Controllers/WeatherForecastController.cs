using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI_Practise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreAPI_Practise.Repository;
using CoreAPI_Practise.Contracts;


namespace CoreAPI_Practise.Controllers
{
    [ApiController]
    [Route("weatherapi")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private IWeatherRepository _weatherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        [Route("sampledata")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("weatherdata")]
        public async Task<IActionResult> GetWeatherList()
        {
            var weatherData = await _weatherRepository.GetWeather();
            return Ok(weatherData);
        }
    }
}
