using Microsoft.EntityFrameworkCore;
using System;
using CSharp.Base.UniversalTemplate.EF_Core_Example;

namespace EF_Core_UniversalTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class EmployeeDb : DbContext
        {
            public DbSet<_001_Model.Employee> Employees { get; set; }
        }
    }
}
