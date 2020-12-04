using System;
using System.Collections.Generic;
using System.Text;

namespace Esercitazione.Work.Core.Repository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> Get(Func<T, bool> filter = null);
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);

    }
}
