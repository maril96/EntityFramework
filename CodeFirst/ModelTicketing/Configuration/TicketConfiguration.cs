using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.ModelTicketing.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            //var ticketModel = modelBuilder.Entity<Ticket>();
            //così evitiamo di scriverlo ogni volta...
            //qui non ci serve!

            builder
                .HasKey(t => t.Id); //non è necessario se rispettano le convenzioni, ma lo facciamo per stare sicuri

            builder
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired(); //non può essere null

            builder
                .Property(t => t.Description)
                .HasMaxLength(500);

            builder
                .Property(t => t.Category)
                .IsRequired();
            //Avremmo potuto usare le DataAnnotations nella classe Ticket. Lì NON si usano le FluentAPI

            builder
                .Property(t => t.Requestor)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(t => t.Notes) //ogni classe ticket "ha molte" note
                .WithOne(n => n.Ticket) //ciascuna delle quali ha un solo Ticket
                .HasForeignKey(n => n.TicketId) //con questa foreignKey
                .HasConstraintName("FK_Ticket_Notes") //Diamo un nome al constraint: se non lo specifichiamo gli dà lui un nome
                .OnDelete(DeleteBehavior.Cascade); //Se si cancella un elemento si cancellano anche le referenze
                                                   //(La cancellazione si propaga a cascata, seguendo le foreign keys: se cancello un Ticket vengono cancellate le note associate)

            //Per le relazioni N:N basterebbe fare HasMany WithMany, lui poi costruisce da solo la tabella di bridge

            //Per gestire la concorrenza:
            builder
                .Property(t => t.RowVersion)
                .IsRowVersion();
        
        }
    }
}
