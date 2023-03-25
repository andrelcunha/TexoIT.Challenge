using CsvHelper.Configuration.Attributes;

namespace TEXOit.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public IEnumerable<string> Studios { get; set; }
    public IEnumerable<string> Producers { get; set; }
    public bool Winner { get; set; }
}

public class Producer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class MovieRead
{
    [Name("year")]
    public int year { get; set; }
    [Name("title")]
    public string title { get; set; }
    public string studios { get; set; }
    [Name("producers")]
    public string producers { get; set; }
    [Name("winner")]
    public string winner { get; set; }
}

