using Microsoft.EntityFrameworkCore;
using TEXOit.Core.Data;
using TEXOit.Core.Models;

namespace TEXOit.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Movie>> ObterTodos()
        {
            return await _context.Movies
                .Include(x=>x.Studios)
                .Include(x=>x.Producers)
                .ToListAsync();
        }

        public async Task<Movie> ObterPorId(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public void Adicionar(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void Atualizar(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
