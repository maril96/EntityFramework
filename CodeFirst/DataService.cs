using CodeFirst.Context;
using CodeFirst.ModelTicketing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst
{
    public class DataService
    {
        public void ListLazy()
        {
            using var ctx = new TicketContext();
            foreach (var t in ctx.Tickets)
            {
                System.Console.WriteLine($"[{t.Id}] {t.Title}");
                foreach (Note n in t.Notes)
                {
                    Console.WriteLine($"\t{n.Comments}");//Non vedo nulla!Quando faccio il ToList sulla lista dei Tickets le NavigationProperties non vengono popolate.
                }
            }
            //Se mi serve fino alla fine posso evitarmi le parentesi
            
            
        }
        public List<Ticket> ListEager()
        {
            using var ctx = new TicketContext();
            return ctx.Tickets
                .Include(t => t.Notes)
                .ToList();
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

        public bool AddNote(Note newNote)
        {
            try
            {
                using var ctx = new TicketContext();
                


                if (newNote != null)
                {
                    
                    var ticket = ctx.Tickets.Find(newNote.TicketId);
                    if (ticket != null)
                    {
                        ticket.Notes.Add(newNote);
                        ctx.SaveChanges();
                    }

                    //Non posso inserire direttamente dentro Note: bisogna passare attraverso la Navigation Property
                    //altrimenti dovrei riempire il campo Ticket dentro la nota                   
                    //potrei anche fare:

                    //newNote.Ticket=ticket; //qui aggiorno la navigation property. Altrimenti lui prova ad inserire un nuovo ticket.
                    //ctx.Notes.Add(newNote);
                    //ctx.SaveChanges();
                    

                }
                else Console.WriteLine("Nota non può essere nullo");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: "+e.Message);
                return false;
            }
        }
        public Ticket GetTicketByIDViaSP (int id)
        {
            //Richiamo una SP salvata in SQL in SSMS
            using var ctx = new TicketContext();
            SqlParameter idParam = new SqlParameter("@id", id);
            var result =ctx.Tickets.FromSqlRaw("exec stpGetTicketById @id", idParam).AsEnumerable(); //AsEnumerable() mi assicura che mi restituisca un IQuerable

            //potrebbe in teoria esserci più di un risultato, ma sarà unico perchè vado per ID
            return result.FirstOrDefault();
        }

        public Ticket GetTicketByID(int id)
        {
            using var ctx = new TicketContext();
            if (id > 0)
                return ctx.Tickets.Find(id);
            //ritorna null se l'id è negativo o non è presente un oggetto con quell'id
            return null;
        }

        public bool Edit(Ticket ticket)
        {
            using var ctx = new TicketContext();
            bool saved;
           // do {
                try
                {

                    if (ticket == null)
                        saved = false;
                    Console.WriteLine("Sto per editare Ticket...");
                    Console.ReadKey(); //così fermo l'esecuzione per testare che succede se faccio una modifica intanto

                    ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                    ctx.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    //fare cose
                    Console.WriteLine("Error:" + e.Message);
                    //Così semplicemente mi scrive l'errore e va avanti...
                    //il fatto del do while si fa se qui faccio cose tipo riaggiornare il mio db e lavorare su quello aggiornato.
                    saved = false;
                }

            //} while (!saved);
            //così provo a rifarlo in loop
            return saved;
         }
    }
}