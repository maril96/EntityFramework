using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.ModelTicketing
{
    public class Ticket
    {
        //Dovremmo mettere il costruttore che inizializza la lista, altrimenti bisogna poi gestire gli eventuali null

        public Ticket()
        {
            //Inizializziamo le navigation properties, che potremmo andare ad esplorare...
            Notes = new List<Note>();
        }

        //Le DataAnnotations qui sono le stesse che abbiamo scritto come FluentAPI nel Context.
        //Lui controlla prima le FluentAPI, poi le DataAnnotations e poi cerca di andare di default, se non riesce tira fuori un'Eccezione. 
        //[Key]
        public int Id { get; set; } 
        //così lui la prende direttamente come chiave primaria
        public DateTime IssueDate { get; set; }//data creazione
        //[Required]
        //[MaxLength(100)]
        public string Title { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }
        //[Required]
        public string Category { get; set; } 
        public string Requestor { get; set; }
        public string Priority { get; set; }
        public string State { get; set; } //Nuovo/InEsecuzione/Chiuso


        //Navigation property monodirezionale
        public virtual List<Note> Notes { get; set; }
       
    }
}
