using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UserContext")
        {
            // Вот эта штука по Default не проставляется в Console application
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public DbSet<UserTMP> Users { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }              

    }

    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserContext context)
        {
            context.Airplanes.AddOrUpdate();
            context.Users.AddOrUpdate();

            base.Seed(context);
        }
    }
}
