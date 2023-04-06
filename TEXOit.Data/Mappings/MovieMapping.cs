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

            builder.Property(e => e.Winner);  

            builder.ToTable("Movies");

        }
    }
}
