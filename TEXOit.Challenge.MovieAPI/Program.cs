using TEXOit.Challenge.MovieAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.MapControllers();

app.Run();

public partial class Program { }