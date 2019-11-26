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
        public DbSet<UserDocument> UserDocument { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Phone> Phones { get; set; }  


    }

    internal sealed class CustomDropCreateDatabaseAlways : DropCreateDatabaseAlways<TrainintDBContext>
    {
        protected override void Seed(TrainintDBContext context)
        {
            var user = new Models.User.User()
            {
                Age = 23,
                Name = "Jon"
            };

            var userTwo = new Models.User.User()
            {
                Age = 50,
                Name = "Dima"
            };

            context.Users.Add(user);
            context.Users.Add(userTwo);

            context.Airplanes.Add(new Airplane()
            {
                Name = "Boeing 717",
                Year = 1999,
                CountWheel = 3
            });

            context.SaveChanges();

            context.UserDocument.Add(new Models.User.UserDocument()
            {
                UserId = 1,
                Description = "INN",
                Type = UserDocument.TypeDocument.INN
            });

            context.UserProfiles.Add(new UserProfile()
            {
                Id = user.Id,
                Height = 180,
                Weight = 80
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
