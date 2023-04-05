using TEXOit.Core.Models;
using TEXOit.Data.Repository;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Services
{
    public class PopulateDb : IPopulateDb
    {
        private readonly List<MovieDTO> _movies = new List<MovieDTO>();
        private readonly IMovieRepository _movieRepository;

        public PopulateDb(CsvService csvService, IMovieRepository repository)
        {
            var csv = csvService;
            _movies = csv.records;
            _movieRepository = repository;

        }
        public void ImpotCsvData()
        {
            if (_movies.Any())
            {
                List<Movie> movies = new List<Movie>();
                if (!_movieRepository.ObterTodos().Result.Any())
                {
                    movies = _movies.Select(m => ConvertMovieDto(m)).ToList();
                }
                if (movies.Any())
                {
                    movies.ForEach(m => _movieRepository.Adicionar(m));
                    _movieRepository.UnitOfWork.Commit();
                }
            }
        }

        

        private Movie ConvertMovieDto(MovieDTO movieDTO)
        {
            return new Movie
            {
                Title = movieDTO.title,
                Year = movieDTO.year,
                Studios = GetStudios(movieDTO.studios),
                Producers = GetProducers(movieDTO.producers),
                Winner = movieDTO.winner == "yes",
            };
        }

        private ICollection<Studio> GetStudios(string flatted)
        {
            List<string> stringList = BreakElements(flatted);
            var studios = stringList.Select(s => GetStudio(s).Result).ToList();
            return studios;

        }

        private ICollection<Producer> GetProducers(string flatted)
        {
            List<string> stringList = BreakElements(flatted);
            return stringList.Select(p => GetProducer(p).Result).ToList();

        }

        private async Task<Studio> GetStudio(string name)
        {
            var movies = await _movieRepository.ObterTodos();
            var studios = movies.DistinctBy(m => m.Studios)
                .SelectMany(s => s.Studios);
            return studios
                .DefaultIfEmpty(new Studio { Name = name })
                .FirstOrDefault(s => s.Name == name) ?? new Studio { Name = name };
        }

        private async Task<Producer> GetProducer(string name)
        {
            var movies = await _movieRepository.ObterTodos();
            var producers = movies.DistinctBy(m => m.Producers)
                .SelectMany(s => s.Producers);
            return producers
                .DefaultIfEmpty(new Producer { Name = name })
                .FirstOrDefault(p => p.Name == name) ?? new Producer { Name = name };
        }

        private List<string> BreakElements(string elements)
        {
            elements = elements.Replace("and", ",");
            List<string> result = elements.Split(',').Select(e => e.Trim()).ToList();
            return result;
        }
    }
}
