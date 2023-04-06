using Microsoft.AspNetCore.Mvc;
using TEXOit.Challenge.MovieAPI.Services;
using TEXOit.Core.Models;
using TEXOit.Data;
using TEXOit.Data.Repository;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPopulateDb _populateDb;

        public MovieController(IMovieRepository repository)
        {
            _movieRepository = repository;
     
        }



        [HttpGet(Name ="GetMovies")]
        public async Task<IEnumerable<MovieDTO>> Get()
        {
            var movies  = _movieRepository.ObterTodos().Result;
            var moviesDto = movies.Select(x => new MovieDTO 
            {
                title = x.Title,
                year = x.Year,
                studios = string.Join(", ", x.Studios.Select(s=>s.Studio.Name)),
                producers = string.Join( ", ", x.Producers.Select(p=>p.Producer.Name)),
                winner = x.Winner?"yes":string.Empty
            });
            return moviesDto;
        }

        

        

       

        

        

        
    }
}