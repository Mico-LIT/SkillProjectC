using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace EF_CodeFirst.Examples._013_ConfigModels
{
    class _001_ConfigModel
    {
        public class PhoneContext : DbContext
        {
            public PhoneContext() : base("DefaultConnection")
            { }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Phone> Phones { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new PhoneConfiguration());
                modelBuilder.Configurations.Add(new CompanyConfiguration());
            }
        }

        public class PhoneConfiguration : EntityTypeConfiguration<Phone>
        {
            public PhoneConfiguration()
            {
                ToTable("Mobiles").HasKey(p => p.Ident);
                Property(p => p.Name).IsRequired().HasMaxLength(30);
            }
        }

        public class CompanyConfiguration : EntityTypeConfiguration<Company>
        {
            public CompanyConfiguration()
            {
                ToTable("Manufacturers").Property(c => c.Name).IsRequired().HasMaxLength(30);
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
