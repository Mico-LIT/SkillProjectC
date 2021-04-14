using EF_Core_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_App
{
    class Operations
    {
        public static void Create(User user)
        {
            using (Context db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static User Read(int userId)
        {
            using (var db = new Context())
            {
                var userFind = db.Users.FirstOrDefault(x => x.Id == userId);
                return userFind;
            }
        }

        public static void Update(User user)
        {
            using (var db = new Context())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }
        public static void Delete(User user)
        {
            using (var db = new Context())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
