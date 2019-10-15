using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst
{
    public class UserContext : DbContext
    {
        //public UserContext() : base("name=testDB")
        //{ }

        public DbSet<UserTMP> Users { get; set; }

    }
}
