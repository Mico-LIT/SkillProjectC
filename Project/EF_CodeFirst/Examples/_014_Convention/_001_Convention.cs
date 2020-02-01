using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace EF_CodeFirst.Examples._014_Convention
{
    class _001_Convention
    {

        public class PhoneContext : DbContext
        {
            public PhoneContext() : base("DefaultConnection")
            { }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Phone> Phones { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Add(new StringConvention());
                modelBuilder.Conventions.Add(new NameConvention());
            }
        }

        public class StringConvention : Convention
        {
            public StringConvention()
            {
                Properties<string>().Configure(s => s.HasMaxLength(150));
            }
        }

        public class NameConvention : Convention
        {
            public NameConvention()
            {
                Properties<string>()
                    .Where(s => s.Name == "Name")
                    .Configure(s => s.HasMaxLength(30).IsRequired());
            }
        }

        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public ICollection<Phone> Phones { get; set; }
            public Company()
            {
                Phones = new List<Phone>();
            }
        }

        public class Phone
        {
            public int Ident { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }

            public int CompanyId { get; set; }
            public Company Company { get; set; }
        }
    }
}
