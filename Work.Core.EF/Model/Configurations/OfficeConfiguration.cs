using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Esercitazione.Work.Core.Model;

namespace Esercitazione.Work.Core.EF.Model.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {

            builder
                .HasMany(o => o.Employees)
                .WithOne(e => e.Office)
                .HasForeignKey(e => e.OfficeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
