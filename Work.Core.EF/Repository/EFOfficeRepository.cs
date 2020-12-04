using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esercitazione.Work.Core.EF.Context;
using Esercitazione.Work.Core.Model;
using Esercitazione.Work.Core.Repository;

namespace Esercitazione.Work.Core.EF.Repository
{
    public class EFOfficeRepository : IOfficeRepository
    {
        public bool Add(Office item)
        {
            using (var ctx=new WorkContext())
            {
                if (item == null) return false;

                ctx.Offices.Add(item);                 
                ctx.SaveChanges();
                return true;
            }
        }

        public bool DeleteById(int id)
        {
            using (var ctx = new WorkContext())
            {
                if (id <= 0) return false;

                var office = ctx.Offices.Find(id);

                if (office != null)
                {
                    ctx.Offices.Remove(office);
                    ctx.SaveChanges();
                }
                return true;
            }
        }

        public IEnumerable<Office> Get(Func<Office, bool> filter = null)
        {
            using (var ctx = new WorkContext())
            {
                if (filter != null)
                    return ctx.Offices
                        .Where(filter).ToList();

                return ctx.Offices
                    .ToList();
            }
        }

        public Office GetById(int id)
        {
            using (var ctx = new WorkContext())
            {
                if (id <= 0) return null;

                return ctx.Offices
                    .Where(o => o.Id == id)
                    .SingleOrDefault();
            }
        }

        public bool Update(Office item)
        {
            using (var ctx = new WorkContext())
            {
                try
                {
                    ctx.Entry<Office>(item).State = EntityState.Modified;
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
