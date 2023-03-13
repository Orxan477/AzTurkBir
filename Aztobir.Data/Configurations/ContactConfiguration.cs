using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(14).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        }
    }
}
