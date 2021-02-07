using EF_CodeFirst.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._008_GenericRepository
{
    public class _001_GenericRepository
    {
        public _001_GenericRepository()
        {
            var userRep = new EFGenericRepository<User>(new TrainintDBContext());

            var users = userRep.GetAll();

            foreach (var item in users)
            {
                Console.WriteLine($"Name: {item.Name} UserProfileId: {item.UserProfile}");
            }

            Console.WriteLine(new string('_', 20));

            users = userRep.GetWithInclude(x => x.UserProfile);

            foreach (var item in users)
            {
                Console.WriteLine($"Name: {item.Name} UserProfileId: {item.UserProfile?.Id}");
            }

            Console.WriteLine(new string('_', 20));

            users = userRep.GetWithInclude(x => x.UserProfile?.Id == 1, x => x.UserProfile);

            foreach (var item in users)
            { 
                Console.WriteLine($"Name: {item.Name} UserProfileId: {item.UserProfile?.Id}");
            }
        }
    }
}
