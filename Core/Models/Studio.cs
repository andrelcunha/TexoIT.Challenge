namespace TEXOit.Core.Models;

public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MovieStudio> Movies { get; set; }
}

