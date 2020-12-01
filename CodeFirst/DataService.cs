using CodeFirst.Context;
using CodeFirst.ModelTicketing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst
{
    public class DataService
    {
        public List<Ticket> List()
        {
            using var ctx = new TicketContext();
            //Se mi serve fino alla fine posso evitarmi le parentesi
            return ctx.Tickets.ToList();
            
        }
        public bool Add(Ticket ticket)
        {
            try
            {
                using var ctx = new TicketContext();

                if (ticket != null)
                {
                    ctx.Tickets.Add(ticket);
                    ctx.SaveChanges(); //ATTENZIONE!! Bisogna fare il SaveChanges!
                }
                else
                    Console.WriteLine("Ticket non può essere nullo");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: "+e.Message);
                return false;
            }



        }
    }
}