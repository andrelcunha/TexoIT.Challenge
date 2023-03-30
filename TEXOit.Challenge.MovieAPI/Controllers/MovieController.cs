using Microsoft.AspNetCore.Mvc;
using TEXOit.Core.Models;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<MovieDBO> _movies = new List<MovieDBO>();
        //private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

        //private readonly ILogger<MovieController> _logger;

        public MovieController(CsvService csvService)
        {
            //_logger = logger;
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
        public async Task<IEnumerable<MovieDBO>> Get()
        {
            return _movies.ToArray();
        }
    }
}