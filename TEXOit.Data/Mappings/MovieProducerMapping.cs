using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TEXOit.Core.Models;

namespace TEXOit.Data.Mappings
{
    public class MovieProducerMapping : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.MovieId);

            builder.Property(c => c.ProducerId);

            builder.ToTable("MovieProducers");
        }
    }
}
