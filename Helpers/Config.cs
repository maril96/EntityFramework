using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Helpers
{
    public class Config
    {
        
        //optionBuilder.UseSqlServer("connString"); //vorremmo NON scrivere la stringa di connessione nel codice
        //Questo eviterà di ricompilare il programma nel caso in cui cambiassimo il db a cui puntare
        //Quindi noi gli passeremo la stringa di connessione mettendola in un file di configurazione (che si trovano in formato Json)
        //la convenzione è creare un file di configurazione chiamato appsettings.Json
        private static IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) //così sono sicuro che lo cerca nella cartella in cui sto lavorando (la stessa in cui ho l'eseguibile)
            .AddJsonFile("appsettings.json")
            .Build();

        public static string GetConnectionString(string connStringName)
        {
            return config.GetConnectionString(connStringName);
        }
        
        public static IConfigurationSection GetSection(string sectionName)
        {
            return config.GetSection(sectionName);
        }

            //così leggiamo la connection string dal file di configurazione
            //oppure:
            //string connString= config.GetSection("ConnectionStrings")["TicketDb"]

            //Così facendo il file da cui prendo la connection string è esterno al programma. Se faccio disassembly leggo la connection string
            //Per questioni di sicurezza si potrebbe mettere negli userSecrets (che non faremo), e si può invece salvarla lato server
        
    }
}
