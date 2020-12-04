using System;
using System.Collections.Generic;
using System.Text;

namespace Esercitazione.Work.Core.Model
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
