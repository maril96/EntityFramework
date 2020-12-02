using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;

namespace Ticketing.Core.Repository
{
    public interface INoteRepository : IRepository<Note>
    {//in questo modo evito di portarmi dietro il generic,
        //inoltre mi permette di creare metodi che invece sono specifici per le singole entità
    }
}
