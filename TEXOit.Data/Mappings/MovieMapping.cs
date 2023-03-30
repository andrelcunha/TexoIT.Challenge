using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TEXOit.Core.Models;

namespace TEXOit.Data.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Year)
                .IsRequired()
                .HasColumnType("int");

            builder.HasMany(c => c.Producers)
                .WithMany(c => c.Movies);

            builder.HasMany(c => c.Studios)
                .WithMany(c => c.Movies);

            builder.ToTable("Movies");

        }
    }
}
