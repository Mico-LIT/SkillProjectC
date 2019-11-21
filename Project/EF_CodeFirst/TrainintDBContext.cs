using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EF_CodeFirst.Models.Other;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst
{
    public class TrainintDBContext : DbContext
    {
        static TrainintDBContext()
        {
            // Вот эта штука по Default не проставляется в Console application. Их App.config
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public TrainintDBContext() : base("name=TrainintDBContext")
        {
            //Database.Delete();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, DataContextConfiguration>());

            if (ConfigurationManager.AppSettings["InitNewDB"].ToUpper() == bool.TrueString.ToUpper())
                Database.SetInitializer(new CustomDropCreateDatabaseAlways());
            else
                Database.SetInitializer(new CreateDatabaseIfNotExists<TrainintDBContext>());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<PersonalDocument> PersonalDocuments { get; set; }


    }

    internal sealed class CustomDropCreateDatabaseAlways : DropCreateDatabaseAlways<TrainintDBContext>
    {
        protected override void Seed(TrainintDBContext context)
        {
            context.Users.Add(new Models.User.User()
            {
                Age = 23,
                Name = "Jon"
            });

            context.Airplanes.Add(new Airplane()
            {
                Name = "Boeing 717",
                Year = 1999,
                CountWheel = 3
            });

            context.SaveChanges();

            context.PersonalDocuments.Add(new Models.User.PersonalDocument()
            {
                UserId = 1,
                Description = "INN",
                Type = PersonalDocument.TypeDocument.INN
            });

            context.SaveChanges();


            //base.Seed(context);
        }
    }

    internal sealed class DataContextConfiguration : DbMigrationsConfiguration<TrainintDBContext>
    {
        public DataContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UserContext";
        }
    }

    //internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //    protected override void Seed(UserContext context)
    //    {
    //        context.Airplanes.AddOrUpdate();
    //        context.Users.AddOrUpdate();

    //        base.Seed(context);
    //    }
    //}
}
