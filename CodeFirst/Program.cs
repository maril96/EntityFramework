using CodeFirst.ModelTicketing;
using System;
using System.Collections.Generic;
using Ticketing.Core.Model;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            //Mi creo una classe che esegua i vari comandi, nel main così leggo solo il comando e poi delego questa classe.
            Console.WriteLine("==Ticket Management==");

            bool quit = false;
            do
            {
                Console.WriteLine("Comando: ");
                string command = Console.ReadLine();
                Console.WriteLine(" ");
                switch (command)
                {
                    case "q":
                        quit = true;
                        break;
                    case "a":
                        //Add
                        Ticket ticket = new Ticket();

                        ticket.Title=GetData("Titolo");
                        ticket.Description = GetData("Descrizione");
                        ticket.Category = GetData("Categoria");
                        ticket.Priority = GetData("Priorità");
                        ticket.Requestor = "Marilena";
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;

                        var result=dataService.Add(ticket);
                        Console.WriteLine("Operation" + (result ? "Completed" : "Failed!"));
                        break;
                    case "n":
                        //Add note
                        var ticketId = GetData("Ticket ID");
                        var comment = GetData("Commento");
                        int.TryParse(ticketId, out int tId);
                        Note newNote = new Note {
                        TicketId=tId,
                        Comments=comment,
                        
                        };


                        var resultN = dataService.AddNote(newNote);
                        Console.WriteLine("Operation" + (resultN ? "Completed" : "Failed!"));
                        break;
                    case "ll":
                        //List
                        System.Console.WriteLine("---Ticket List---");
                        
                        dataService.ListLazy();
                        
                        //Faccio stampare qui per separare i ruoli.
                        //Ma poi no perchè mi serve avere il contesto per fare il LazyLoading
                       
                        System.Console.WriteLine("------fine-----");

                        break;
                    case "le":
                        Console.WriteLine("List Eager");
                        List<Ticket> tickets = dataService.ListEager();
                        foreach (var t in tickets)
                        {
                            System.Console.WriteLine($"[{t.Id}] {t.Title}");
                            foreach (Note n in t.Notes)
                            {
                                Console.WriteLine($"\t{n.Comments}");//Non vedo nulla!Quando faccio il ToList sulla lista dei Tickets le NavigationProperties non vengono popolate.
                            }
                        }

                        break;
                    case "e":
                        //Edit
                        //dataService.Edit(ticket);
                        var ticketId3 = GetData("Ticket ID");
                        int.TryParse(ticketId3, out int tId3);
                        Ticket ticket3 = dataService.GetTicketByID(tId3);

                        ticket3.Title = GetData("Title", ticket3.Title);
                        ticket3.Description = GetData("Descrizione", ticket3.Description);
                        ticket3.Category = GetData("Categoria", ticket3.Category);
                        ticket3.Priority = GetData("Priorità", ticket3.Priority);
                        ticket3.State = GetData("Stato", ticket3.State);

                        bool editResult = dataService.Edit(ticket3);
                        Console.WriteLine("Operation "+(editResult? "Completed" : "Failed!"));
                        break;
                    case "d":
                        //Delete
                        //dataService.Delete(ticket);
                        break;
                    case "sp":
                        var ticketId2 = GetData("Ticket ID");
                        int.TryParse(ticketId2, out int tId2);
                        var ticket2= dataService.GetTicketByIDViaSP(tId2);
                        Console.WriteLine(ticket2!= null ? $"{ticket2.Title }" : "Failed!");
                        break;
                    default: 
                        Console.WriteLine("Comando sconosciuto");
                        break;
                }
            } while (!quit);

            Console.WriteLine("==Bye Bye==");



        }

        private static string GetData(string message)
        {
            //codice per recuperare i dati di un Ticket...
            Console.WriteLine(message+": ");
            return Console.ReadLine();
        }
        private static string GetData(string message, string initialValue)
        {
            //Da riscrivere:
            Console.Write(message + $" ({initialValue}): ");
            //Con Write non va da capo, quindi scrivo subito dopo.
            var value= Console.ReadLine();

            return string.IsNullOrEmpty(value) ? initialValue : value;
            //Così se è già quello giusto conserva lo stato esistente se io faccio direttamente Invio
        }
    }
}
