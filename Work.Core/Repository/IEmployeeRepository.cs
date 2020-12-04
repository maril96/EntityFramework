using System;
using System.Collections.Generic;
using System.Text;
using Esercitazione.Work.Core.Model;

namespace Esercitazione.Work.Core.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<Employee> GetCollegues(int id);
    }
}
