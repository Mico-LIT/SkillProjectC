using Microsoft.EntityFrameworkCore;
using System;
using CSharp.Base.UniversalTemplate.EF_Core_Example;
using System.Linq;
using EF_Core_UniversalTemplate.DataBase;

namespace EF_Core_UniversalTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var sqlRepository = new SqlRepository<_001_Model.Employee>(new CompanyDb()))
            {
                sqlRepository.Add(new _001_Model.Employee() { Name = "1234" });
                sqlRepository.Commit();
                var employees = sqlRepository.FindAll().ToListAsync().Result;
            }
        }
    }
}
