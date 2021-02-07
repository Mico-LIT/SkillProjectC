using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity;

namespace EF_CodeFirst.Examples._003_ConnectionTable
{
    public class _001_OneToOne
    {
        public _001_OneToOne()
        {
            using (var db = new TrainintDBContext())
            {
                var user = db.Users.FirstOrDefault();

                if (user != null)
                {
                    var userInfo = db.UserProfiles.Include(x=>x.User.Documents).Where(x => x.User.Id == user.Id).FirstOrDefault();
                    Console.WriteLine(userInfo);
                }
            }
        }
    }
}
