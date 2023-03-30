using Microsoft.EntityFrameworkCore;
using TEXOit.Core.Models;

namespace TEXOit.Data
{
    public class MoviesContext:DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options) { }

        DbSet<Movie> Movies { get; set; }
        DbSet<Producer> Producers { get; set; }
        DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesContext).Assembly);
        }
    }
}