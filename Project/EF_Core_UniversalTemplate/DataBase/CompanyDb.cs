using CSharp.Base.UniversalTemplate.EF_Core_Example;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_UniversalTemplate.DataBase
{
    class CompanyDb : DbContext
    {
        public DbSet<_001_Model.Employee> Employees { get; set; }

        public CompanyDb()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Test");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
