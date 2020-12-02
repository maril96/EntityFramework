using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Core.Repository
{
    public interface IRepository<T> where T:class
    {
        //Idea: avere un repository che possa essere utilizzato per accedere alle varie entità del modello.
        //Per cui introduco un generics e dico che dev'essere una classe

        //Implementare le CRUD
        IEnumerable<T> Get(Func<T, bool> filter = null);
        //Se non passo nulla, quindi il filter è null di default, restituisco tutta la lista, altrimenti i campi che soddisfano il predicato passato al metodo get
        //tramite ad esempio una Lambda-Expression
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);

//Dietro questa interfaccia nasconderò la tecnica di accesso al dato.
    }
}
