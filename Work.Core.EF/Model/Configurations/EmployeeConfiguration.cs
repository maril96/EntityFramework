using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Esercitazione.Work.Core.Model;

namespace Esercitazione.Work.Core.EF.Model.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.EmployeeID);

            builder
                .Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.BadgeNumber)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
