using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(85).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(250).IsRequired();
        }
    }
}
