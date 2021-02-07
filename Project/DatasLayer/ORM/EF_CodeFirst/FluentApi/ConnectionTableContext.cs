using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.FluentApi
{
    public class ConnectionTableContext : DbContext
    {
        public DbSet<OneToZeroOrOne.Phone> OneToZeroOrOne_Phones { get; set; }
        public DbSet<OneToZeroOrOne.Company> OneToZeroOrOne_Company { get; set; }


        public DbSet<OneToMany.Phone1> OneToMany_Phones { get; set; }
        public DbSet<OneToMany.Company1> OneToMany_Company { get; set; }


        public DbSet<ManyToMany.Phone2> ManyToMany_Phones { get; set; }
        public DbSet<ManyToMany.Company2> ManyToMany_Company { get; set; }


        public ConnectionTableContext() : base("FluentApiCondext")
        {
            Database.SetInitializer(new CustomDropCreateDatabaseAlways());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ConnectionTableContext>());
        }

        static ConnectionTableContext()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region OneToZeroOrOne modelBuilder
            
            var forTest = false;

            if (forTest)
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

            modelBuilder.Entity<OneToZeroOrOne.Phone>().Map(x => x.ToTable("OneToZeroOrOne_Phone"));
            modelBuilder.Entity<OneToZeroOrOne.Company>().Map(x => x.ToTable("OneToZeroOrOne_Company"));

            #endregion

            #region OneToMany modelBuilder

            modelBuilder.Entity<OneToMany.Company1>()
                .HasMany(x => x.Phones)
                .WithRequired(x => x.Company)
                .HasForeignKey(x => x.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OneToMany.Phone1>().Map(x => x.ToTable("OneToMany_Phone"));
            modelBuilder.Entity<OneToMany.Company1>().Map(x => x.ToTable("OneToMany_Company"));

            #endregion

            #region ManyToMany modelBuilder

            modelBuilder.Entity<ManyToMany.Phone2>()
                .HasMany(x => x.Companies)
                .WithMany(x => x.Phones)
                .Map(m =>
                {
                    m.ToTable("MobileCompanies");
                    m.MapLeftKey("MobileId");
                    m.MapRightKey("CompanyId");
                });

            modelBuilder.Entity<ManyToMany.Phone2>().Map(x => x.ToTable("ManyToMany_Phone"));
            modelBuilder.Entity<ManyToMany.Company2>().Map(x => x.ToTable("ManyToMany_Company"));

            #endregion


            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

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
            public class Phone1
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public Company1 Company { get; set; }
                public int Manufacturer { get; set; }
            }

            public class Company1
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public ICollection<Phone1> Phones { get; set; }
                public Company1()
                {
                    Phones = new List<Phone1>();
                }
            }
        }
        public class ManyToMany
        {
            public class Phone2
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public ICollection<Company2> Companies { get; set; }

                public Phone2()
                {
                    Companies = new List<Company2>();
                }
            }

            public class Company2
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public ICollection<Phone2> Phones { get; set; }

                public Company2()
                {
                    Phones = new List<Phone2>();
                }
            }
        }

    }
}
