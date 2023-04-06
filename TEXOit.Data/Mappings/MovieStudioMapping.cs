using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TEXOit.Core.Models;

namespace TEXOit.Data.Mappings
{
    public class MovieStudiioMapping : IEntityTypeConfiguration<MovieStudio>
    {
        public void Configure(EntityTypeBuilder<MovieStudio> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.MovieId);

            builder.Property(c => c.StudioId);

            builder.ToTable("MovieStudios");
        }
    }
}
