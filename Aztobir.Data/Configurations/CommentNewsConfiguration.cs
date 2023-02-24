using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.UI.Configurations
{
    public class CommentNewsConfiguration : IEntityTypeConfiguration<CommentNews>
    {
        public void Configure(EntityTypeBuilder<CommentNews> builder)
        {
            builder.Property(x => x.Comment).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
        }
    }
}
