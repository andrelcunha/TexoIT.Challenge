using Microsoft.AspNetCore.Mvc;
using TEXOit.Challenge.MovieAPI.Models;
using TEXOit.Challenge.MovieAPI.Services;

namespace TEXOit.Challenge.MovieAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<MovieRead> _movies = new List<MovieRead>();
        //private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CsvService csvService)
        {
            _logger = logger;
            var csv = csvService;
            _movies = csv.records;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name ="GetMovies")]
        public async Task<IEnumerable<MovieRead>> Get()
        {
            return _movies.ToArray();
        }
    }
}