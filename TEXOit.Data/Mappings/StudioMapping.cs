using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TEXOit.Core.Models;

namespace TEXOit.Data.Mappings
{
    public class StudioMapping : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasMany(c => c.Movies)
                .WithMany(c => c.Studios);

            builder.ToTable("Studios");

        }
    }
}
