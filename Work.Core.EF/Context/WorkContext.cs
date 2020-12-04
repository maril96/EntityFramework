using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Esercitazione.Work.Core.EF.Model.Configurations;
using Esercitazione.Work.Core.Model;

namespace Esercitazione.Work.Core.EF.Context
{
    public class WorkContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = Helpers.Config.GetConnectionString("WorkDb");
            optionBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration<Office>(new OfficeConfiguration());
        }
    }
}
