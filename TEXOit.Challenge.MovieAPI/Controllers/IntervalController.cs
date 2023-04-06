using Microsoft.AspNetCore.Mvc;
using TEXOit.Core.Models;
using TEXOit.Data;
using TEXOit.Data.Repository;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IntervalController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;

        public IntervalController(IProducerRepository repository)
        {
            _producerRepository = repository;
        }



        [HttpGet(Name = "GetInterval")]
        public async Task<IntervalDTO> Get()
        {
            return await _producerRepository.ObterInteralo();            
        }

    }
}