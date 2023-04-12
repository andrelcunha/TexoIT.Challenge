using TEXOit.Challenge.MovieAPI.Configuration;

//namespace TEXOit.Challenge.MovieAPI
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddApiConfiguration(builder.Configuration);

//            builder.Services.AddSwaggerConfiguration();

//            builder.Services.AddDependencyInjectionConfiguration();

//            var app = builder.Build();

//            app.UseApiConfiguration(app.Environment);

//            app.MapControllers();

//            app.Run();

//        }
//    }
//}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.MapControllers();

app.Run();

public partial class Program { }