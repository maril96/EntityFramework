using CodeFirst.ModelTicketing;
using System;
using System.Collections.Generic;

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
                    case "l":
                        //List
                        System.Console.WriteLine("---Ticket List---");
                        
                        List<Ticket> tickets = dataService.List();
                        
                        //Faccio stampare qui per separare i ruoli.
                        foreach (var t in tickets)
                        {
                            System.Console.WriteLine($"[{t.Id}] {t.Title}");
                        }
                        System.Console.WriteLine("------fine-----");

                        break;
                    case "e":
                        //Edit
                        //dataService.Edit(ticket);
                        break;
                    case "d":
                        //Delete
                        //dataService.Delete(ticket);
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
    }
}
