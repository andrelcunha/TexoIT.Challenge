using TEXOit.Core.Models;

namespace TEXOit.Data.Repository
{
    public interface IProducerRepository
    {
        Task<IntervalDTO> ObterInteralo();
    }
}