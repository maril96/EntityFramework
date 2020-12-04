using Esercitazione.Work.Core.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Esercitazione.Work.Core.Model;
using Esercitazione.Work.Core.Repository;

namespace Esercitazione.Work.Core.EF.Repository
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        public bool Add(Employee e)
        {
            using (var ctx = new WorkContext())
            {
                if (e == null) return false;

                ctx.Employees.Add(e);
                ctx.SaveChanges();
                return true;
            }
               
        }

        public bool DeleteById(int id)
        {
            using (var ctx = new WorkContext())
            {
                if (id <= 0) return false;

                var employee = ctx.Employees.Find(id);

                if (employee != null)
                {
                    ctx.Employees.Remove(employee);
                    ctx.SaveChanges();
                }
                return true;
            }
        }

        public IEnumerable<Employee> Get(Func<Employee, bool> filter = null)
        {
           using(var ctx= new WorkContext())
            {
                if (filter != null)
                    return ctx.Employees
                        //.Include(e => e.Office)
                        .Where(filter).ToList();

                return ctx.Employees
                    //.Include(e => e.Office)
                    .ToList();
            }
        }

        public Employee GetById(int id)
        {
           using (var ctx= new WorkContext())
            {
                if (id <= 0) return null;

                return ctx.Employees
                    .Where(e => e.EmployeeID == id)
                    .SingleOrDefault();
            }
        }

        public List<Employee> GetCollegues(int id)
        {
           using(var ctx=new WorkContext())
            {
                if (id <= 0) return null;

                Employee employee = ctx.Employees.Find(id);

                return ctx.Employees
                    .Include(e => e.OfficeID)
                    .Where(e => e.OfficeID == employee.OfficeID)
                    .ToList();
                    
            }
        }

        public bool Update(Employee employee)
        {
            using(var ctx = new WorkContext())
            {
                try
                {
                    ctx.Entry<Employee>(employee).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return true;
            }
        }
    }
}
