
using Microsoft.EntityFrameworkCore;
using Ticketing.Core.EF.Model.Configuration;
using Ticketing.Core.Model;
//Quando creo una cartella cambia il namespace: bisogna aggiungerlo!

namespace Ticketing.Core.EF.Context
{
    public sealed class TicketContext : DbContext
    {
        //Connessione al db, metodi per lavorare sui dati del db, informazioni sulla connessione

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {//DbContextOptionBuilder va a definire le configurazioni delle opzioni sulla base di ciò che scriviamo nel metodo
         //Questo metodo verrà invocato dal costruttore della classe base

            string connString = Helpers.Config.GetConnectionString("TicketDb");

            optionBuilder.UseSqlServer(connString);

            optionBuilder.UseLazyLoadingProxies();
        }

        //Lavoriamo in FluentAPI per aggiungere qualche vincolo
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfiguration());
            //ApplyConfiguration chiama il metodo Configure di TicketConfiguration

            modelBuilder.ApplyConfiguration<Note>(new NoteConfiguration());
        }

    }
}
