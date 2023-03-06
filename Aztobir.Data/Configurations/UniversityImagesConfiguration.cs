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
    public class UniversityImagesConfiguration : IEntityTypeConfiguration<UniversityImages>
    {
        public void Configure(EntityTypeBuilder<UniversityImages> builder)
        {
            builder.Property(x => x.Image).IsRequired();
        }
    }
}
