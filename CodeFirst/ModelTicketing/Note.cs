using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.ModelTicketing
{
    public class Note
    {
        //public Note()
        //{
        //    Ticket = new Ticket();
        //}
        //Il costruttore va levato, perché va ad intaccare il meccanismo delle NP (ci sono stati degli aggiornamenti rispetto alle slides viste)
        //Questo costruttore in realtà nella nuova versione non va più definito.
        public int Id { get; set; }
        public string Comments { get; set; }
        public int TicketId { get; set; } //Foreign Key associata a Ticket

        //questa è l'altra direzione della Navigation Property
        //Il virtual è collegato al Lazy loading
        public virtual Ticket Ticket { get; set; }

        //Per gestire la concorrenza:
        public Byte[] RowVersion { get; set; }
    }
}
