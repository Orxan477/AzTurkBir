using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();   
            builder.Property(x => x.PositionId).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Linkedin).HasMaxLength(100);
            builder.Property(x => x.Facebook).HasMaxLength(100);
            builder.Property(x => x.Twitter).HasMaxLength(100);
        }
    }
}
