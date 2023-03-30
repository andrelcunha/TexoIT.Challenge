using CsvHelper.Configuration.Attributes;

namespace TEXOit.Core.Models;

public class MovieDBO
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

