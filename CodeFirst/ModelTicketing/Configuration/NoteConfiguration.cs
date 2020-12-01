using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.ModelTicketing.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Comments)
                .HasMaxLength(1000)
                .IsRequired();

            //Ridefiniamo la foreign key dal punto di vista delle note:
            builder
                .HasOne(n => n.Ticket)
                .WithMany(t => t.Notes)
                .HasForeignKey(n => n.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
