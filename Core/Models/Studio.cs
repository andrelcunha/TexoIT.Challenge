namespace TEXOit.Core.Models;

public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}

