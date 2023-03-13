using Aztobir.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Configurations
{
    public class UniversityFormConfiguration : IEntityTypeConfiguration<UniversityForm>
    {
        public void Configure(EntityTypeBuilder<UniversityForm> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(500).IsRequired();
        }
    }
}
