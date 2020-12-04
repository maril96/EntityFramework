using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esercitazione.Work.Core.Model;
using Esercitazione.Work.Core.Repository;

namespace Esercitazione.Work.Core.BusinessLayer
{
    public class DataService
    {
        private IOfficeRepository officeRepository;
        private IEmployeeRepository employeeRepository;

        public DataService(IOfficeRepository or, IEmployeeRepository er)
        {
            this.officeRepository = or;
            this.employeeRepository = er;
        }

        public bool DeleteEmployee(int id)
        {
           return employeeRepository.DeleteById(id);
        }
        public List<Employee> Get()
        {
            return employeeRepository.Get().ToList();
        } 

        public Employee GetEmployee(int id)
        {
            return employeeRepository.GetById(id);
        }
        public bool Add(Employee e)
        {
            return employeeRepository.Add(e);
        }
        public bool Update(Employee e)
        {
            return employeeRepository.Update(e);
        }
        public List<Employee> GetCollegues(int id)
        {
            return employeeRepository.GetCollegues(id);
        }


    }
}
