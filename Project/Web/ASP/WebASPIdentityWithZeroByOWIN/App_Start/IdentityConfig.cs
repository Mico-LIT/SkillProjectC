using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WebASPIdentityWithZeroByOWIN.App_Start
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(): base("DefaultConnection")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){}

        public int Age { get; set; }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }



















}