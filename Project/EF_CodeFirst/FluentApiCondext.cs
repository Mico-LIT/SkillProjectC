using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst
{
    public class FluentApiCondext : DbContext
    {
        static FluentApiCondext()
        {
            // Вот эта штука по Default не проставляется в Console application. Их App.config
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        public FluentApiCondext() : base("FluentApiCondext") { }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Сопоставление класса с таблицей
            modelBuilder.Entity<Phone>().ToTable("Mobile");

            // Ignore класса
            modelBuilder.Ignore<User>();

            //Переопределение первичного ключа
            modelBuilder.Entity<Phone>().HasKey(p => p.Id);

            //Настроить составной первичный ключ
            modelBuilder.Entity<Phone>().HasKey(p => new { p.Id, p.Number });

            //Сопоставление свойств
            modelBuilder.Entity<Phone>().Property(x => x.Number).HasColumnName("PhoneNumber");

            //столбец мог принимать значения NULL
            modelBuilder.Entity<Phone>().Property(x => x.Discount).IsOptional();
            modelBuilder.Entity<Phone>().Property(x => x.Number).IsRequired();

            // Ignore свойства
            modelBuilder.Entity<Phone>().Ignore(x => x.Users);

            // Настройка строк
            modelBuilder.Entity<Phone>().Property(x => x.Number).HasColumnType("varchar");
            modelBuilder.Entity<Phone>().Property(x => x.Number).HasMaxLength(20);

            modelBuilder.Entity<Phone>().Property(x => x.Price).HasPrecision(15, 2);

            //Сопоставление модели с несколькими таблицами
            modelBuilder.Entity<Phone>().Map(m =>
            {
                m.Properties(p => new {p.Id, p.Number});
                m.ToTable("Mobile");
            }).Map(m =>
            {
                m.Properties(p => new {p.Id, p.Discount, p.Price});
                m.ToTable("MobileInfo");
            });


            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
