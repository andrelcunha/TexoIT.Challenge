using Microsoft.EntityFrameworkCore;
using TEXOit.Core.Data;
using TEXOit.Core.Models;

namespace TEXOit.Data.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly MovieContext _context;

        public ProducerRepository(MovieContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Producer>> ObterTodos()
        {
            return await _context.Producers
                .Include(x => x.Movies)
                .ToListAsync();
        }

        public async Task<IntervalDTO> ObterInteralo()
        {
            var query = await _context.MovieProducers
                .Include(mp => mp.Movie)
                .Include(mp => mp.Producer)
               .Where(x => x.Movie.Winner).ToListAsync();

            var group = query
               .GroupBy(x => x.Producer)
               .Select(g => new
               {
                   Producer = g.Key,
                   Movies = g.Select(x => x.Movie).OrderBy(x => x.Year).ToList(),
               });

            var producers = group
               .Where(x => x.Movies.Count > 1)
               .Select(producer => new
               {
                   Movies = producer.Movies.Select((movie, i) => new ProducerDTO
                   {
                       Producer = producer.Producer.Name,
                       Interval = i > 0 ? movie.Year - producer.Movies[i - 1].Year : 0,
                       PreviousWin = i > 0 ? producer.Movies[i - 1].Year : 0,
                       FollowingWin = movie.Year,
                   })
                   .Where(x => x.PreviousWin > 0)
               })
               .SelectMany(x => x.Movies)
               .OrderBy(x => x.Interval);

            return new IntervalDTO
            {
                Min = producers.Take(1).ToList(),
                Max = producers.TakeLast(1).ToList()
            };
        }

        public async Task<Producer> ObterPorId(int id)
        {
            return await _context.Producers.FindAsync(id);
        }

        public void Adicionar(Producer producer)
        {
            _context.Producers.Add(producer);
        }

        public void Atualizar(Producer producer)
        {
            _context.Producers.Update(producer);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
