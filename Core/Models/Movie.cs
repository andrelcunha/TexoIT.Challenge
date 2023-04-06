namespace TEXOit.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public ICollection<MovieStudio> Studios { get; set; }
    public ICollection<MovieProducer> Producers { get; set; }
    public bool Winner { get; set; }
}