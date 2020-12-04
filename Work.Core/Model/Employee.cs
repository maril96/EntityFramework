using System;
using System.Collections.Generic;
using System.Text;

namespace Esercitazione.Work.Core.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int OfficeID { get; set; }
        public virtual Office Office { get; set; }

    }
}
