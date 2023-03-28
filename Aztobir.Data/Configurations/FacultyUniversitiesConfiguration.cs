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
    public class FacultyUniversitiesConfiguration : IEntityTypeConfiguration<FacultyUniversity>
    {
        public void Configure(EntityTypeBuilder<FacultyUniversity> builder)
        {
            builder.Property(x => x.FacultyId).IsRequired();
            //builder.Property(x => x.UniversityId).IsRequired();
        }
    }
}
