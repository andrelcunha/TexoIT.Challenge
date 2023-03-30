namespace TEXOit.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public virtual ICollection<Studio> Studios { get; set; }
    public virtual ICollection<Producer> Producers { get; set; }
    public bool Winner { get; set; }
}