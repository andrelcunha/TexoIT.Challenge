using TEXOit.Core.Models;
using TEXOit.Data;
using TEXOit.Data.Repository;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Services
{
    public class PopulateDb : IPopulateDb
    {
        private readonly List<MovieDTO> _records;
        private readonly MovieContext _context;


        public PopulateDb(CsvService csvService, MovieContext context)
        {
            _records = csvService.records;
            _context = context;

        }
        public void ImpotCsvData()
        {
            if (_records.Any())
            {
                var _producerList = new List<Producer>();
                var _studioList = new List<Studio>();

                _records.ForEach(movieDTO =>
                {
                    var movie = ConvertMovieDto2Movie(movieDTO);

                    var producersRaw = BreakElements(movieDTO.producers);
                    producersRaw.ForEach(p =>
                    {
                        SaveProducer(p, movie,ref _producerList);
                    });

                    var studiosRaw = BreakElements(movieDTO.studios);
                    studiosRaw.ForEach(s=>
                    { 
                        SaveStudio(s, movie, ref _studioList);
                    });

                });
                _context.SaveChanges();
            }
        }

        private Movie ConvertMovieDto2Movie(MovieDTO movieDTO)
        {
            return new Movie
            {
                Title = movieDTO.title,
                Year = movieDTO.year,
                Winner = movieDTO.winner == "yes",
            };
        }

        private void SaveStudio(string name, Movie movie, ref List<Studio> studios )
        {
            var studio = studios
                .FirstOrDefault(p => p.Name == name);
            if (studio == null)
            {
                studio = new Studio { Name = name };
                studios.Add(studio);
            }

            var movieStudio = new MovieStudio { Movie = movie, Studio = studio };
            _context.Add(movieStudio);
        }

        private void SaveProducer(string name, Movie movie, ref List<Producer> producers)
        {
            var producer = producers
                .FirstOrDefault(p => p.Name == name);
            if (producer == null)
            {
                producer = new Producer { Name = name };
                producers.Add(producer);
            }

            var movieProducer = new MovieProducer { Movie = movie, Producer = producer };
            _context.Add(movieProducer);
        }

        private List<string> BreakElements(string elements)
        {
            elements = elements.Replace("and", ",");
            List<string> result = elements.Split(',').Select(e => e.Trim()).ToList();
            return result;
        }
    }
}
