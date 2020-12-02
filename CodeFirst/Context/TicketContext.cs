using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CodeFirst.ModelTicketing;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using CodeFirst.ModelTicketing.Configuration;
//Quando creo una cartella cambia il namespace: bisogna aggiungerlo!

namespace CodeFirst.Context
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
