using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(3000).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.DilHazirlikEgitimi).HasMaxLength(10).IsRequired();
            builder.Property(x => x.FacultyCount).IsRequired();
            builder.Property(x => x.StudentCount).IsRequired();
            builder.Property(x => x.Image).IsRequired();
        }
    }
}
