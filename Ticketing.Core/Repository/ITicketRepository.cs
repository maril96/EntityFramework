using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;

namespace Ticketing.Core.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicketByTitle(string title);
        //Questo è un metodo specifico per title, non avrebbe senso metterlo nell'interfaccia generica IRepository
        //Lo metto qui perchè poi avrò più classi che la ereditano, una per ogni Persistence Layer fondamentalmente
    }
}
