using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.ModelTicketing
{
    public class Note
    {
        public Note()
        {
            Ticket = new Ticket();
        }
        public int Id { get; set; }
        public string Comments { get; set; }
        public int TicketId { get; set; } //Foreign Key associata a Ticket

        //questa è l'altra direzione della Navigation Property
        //Il virtual è collegato al Lazy loading
        public virtual Ticket Ticket { get; set; }
    }
}
