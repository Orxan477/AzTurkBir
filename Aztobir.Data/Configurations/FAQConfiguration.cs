using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.Property(x => x.Question).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Response).HasMaxLength(500).IsRequired();
        }
    }
}
