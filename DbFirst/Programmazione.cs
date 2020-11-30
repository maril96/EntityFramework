using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst
{
    public partial class Programmazione
    {
        public Programmazione()
        {
            Prenotaziones = new HashSet<Prenotazione>();
            //Questa cosa si fa per evitare di avere una ICollection che sia null, invece qui ne creo un'istanza di tipo HashSet,
            //in modo che il valore di default non sia null, ma ogni campo all'interno viene inizializzato al valore di default. 
            //Questo evita che il programma esploda, ed evita di mettere guardie nel codice.
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int? SalaId { get; set; }
        public TimeSpan? Orario { get; set; }
        public decimal? Prezzo { get; set; }
        public int? PostiDisponibili { get; set; }

        //Qui Movie e Sala vanno a "implementare" la relazione 1:N. Queste sono Reference Navigation Properties.
        public virtual Movie Movie { get; set; }
        public virtual Sale Sala { get; set; }
        
        //Prenotaziones è una Collection Navigation Property
        public virtual ICollection<Prenotazione> Prenotaziones { get; set; }
    }
}
