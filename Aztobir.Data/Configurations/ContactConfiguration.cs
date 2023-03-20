using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aztobir.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(550).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
        }
    }
}
