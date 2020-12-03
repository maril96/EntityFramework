using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.BusinessLayer
{
    public class DataService
    {
        private ITicketRepository ticketRepository;
        private INoteRepository noteRepository;

        #region Temp ... waiting for DI

        //Il solo codice che cambiamo per passare da un'origine dati all'altra è quello nel GetRepository
        public DataService(ITicketRepository ticketRepo, INoteRepository noteRepo)
        {//Così non creo le dipendenze dentro DataService, ma gli vengono passate quando si istanzia
            //In questo modo tutto passa nelle mani dell'injector: quando qui chiedo una certa interfaccia è lui a decidere 
            //l'istanza di quale classe (che la implementa) passare.
            this.ticketRepository = ticketRepo;
            this.noteRepository = noteRepo;
        }
     /*   private ITicketRepository GetTicketRepository()
        {
            return null;
            //return new Ticketing.Core.Mock.Repository.MockTicketRepository();
            //return new Ticketing.Core.EF.Repository.EFTicketRepository();
        }

        private INoteRepository GetNoteRepository()
        {
            return null;
            //return new Ticketing.Core.Mock.Repository.MockNoteRepository();
            // return new Ticketing.Core.EF.Repository.EFNoteRepository();
        }*/

        #endregion
        public void Delete()
        {
            //Da implementare!
        }

        public List<Ticket> List()
        {
            /*   ITicketRepository repo = GetTicketRepository();

               return repo.Get().ToList();*/
            return ticketRepository.Get().ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
               // ITicketRepository repo = GetTicketRepository();

                if (ticket != null)
                {
                    // var result = repo.Add(ticket);
                    var result = ticketRepository.Add(ticket);
                    return result;
                }
                else
                {
                    Console.WriteLine("Ticket non può essere nullo.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public bool AddNote(Note newNote)
        {
            try
            {
               // INoteRepository repo = GetNoteRepository();

                if (newNote != null)
                {
                    //repo.Add(newNote);
                    noteRepository.Add(newNote);
                   
                }
                else
                    Console.WriteLine("Note non può essere nullo.");

                 return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public Ticket GetTicketById(int id)
        {
            // ITicketRepository repo = GetTicketRepository();

            if (id > 0)
                // return repo.GetById(id);
                return ticketRepository.GetById(id);

            return null;
        }

        public bool Edit(Ticket ticket)
        {
            try
            {
                //ITicketRepository repo = GetTicketRepository();

                if (ticket == null)
                    return false;

                Console.WriteLine("Smandrappa il Ticket e poi premi enter ...");
                Console.ReadKey();

                //repo.Update(ticket);
                ticketRepository.Update(ticket);

            }
            catch (Exception ex)
            {
                // ...
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}