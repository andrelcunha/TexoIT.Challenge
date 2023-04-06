namespace TEXOit.Core.Models;

public class Producer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MovieProducer> Movies { get; set; }
}

