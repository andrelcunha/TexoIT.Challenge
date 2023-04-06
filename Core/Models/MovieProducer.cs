namespace TEXOit.Core.Models
{
    public class MovieProducer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
