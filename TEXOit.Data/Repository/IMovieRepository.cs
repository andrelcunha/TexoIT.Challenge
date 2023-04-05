using TEXOit.Core.Data;
using TEXOit.Core.Models;

namespace TEXOit.Data.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
   
        Task<IEnumerable<Movie>> ObterTodos();
        Task<Movie> ObterPorId(int id);

        void Adicionar(Movie movie);
        void Atualizar(Movie movie);
    }
}