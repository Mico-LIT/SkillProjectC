using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.FluentApi
{
    public class ConnectionTableContext : DbContext
    {
        public DbSet<OneToZeroOrOne.Phone> OneToZeroOrOne_Phones { get; set; }
        public DbSet<OneToZeroOrOne.Company> OneToZeroOrOne_Company { get; set; }


        public DbSet<OneToMany.Phone> OneToMany_Phones { get; set; }
        public DbSet<OneToMany.Company> OneToMany_Company { get; set; }


        public DbSet<ManyToMany.Phone> ManyToMany_Phones { get; set; }
        public DbSet<ManyToMany.Company> ManyToMany_Company { get; set; }


        public ConnectionTableContext() : base("FluentApiCondext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region OneToZeroOrOne modelBuilder

            if (false)
            {
                modelBuilder.Entity<OneToZeroOrOne.Phone>()
                    .HasRequired(c => c.Company)
                    .WithOptional(x => x.BestSeller);
            }
            else
            {
                modelBuilder.Entity<OneToZeroOrOne.Phone>()
                    .HasRequired(x => x.Company)
                    .WithRequiredPrincipal(x => x.BestSeller);
                //или так
                //modelBuilder.Entity<OneToZeroOrOne.Company>()
                //    .HasRequired(x => x.BestSeller)
                //    .WithRequiredPrincipal(x => x.Company);
            }

            #endregion

            #region OneToMany modelBuilder

            #endregion

            #region ManyToMany modelBuilder

            modelBuilder.Entity<ManyToMany.Phone>()
                .HasMany(x => x.Companies)
                .WithMany(x => x.Phones)
                .Map(m =>
                {
                    m.ToTable("MobileCompanies");
                    m.MapLeftKey("MobileId");
                    m.MapRightKey("CompanyId");
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }


        public class OneToZeroOrOne
        {
            public class Phone
            {
                public int Id { get; set; }
                public string Name { get; set; }

                public Company Company { get; set; }
            }

            public class Company
            {
                public int Id { get; set; }
                public string Name { get; set; }

                public Phone BestSeller { get; set; }
            }
        }
        public class OneToMany
        {
            public class Phone
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public Company Company { get; set; }
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
        }
        public class ManyToMany
        {
            public class Phone
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public ICollection<Company> Companies { get; set; }

                public Phone()
                {
                    Companies = new List<Company>();
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
        }

    }
}
