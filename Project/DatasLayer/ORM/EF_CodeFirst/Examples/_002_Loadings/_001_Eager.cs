using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_CodeFirst.Examples._002_Loadings
{
    /// <summary>
    /// Жадная загрузка
    /// </summary>
    public class _001_Eager
    {
        public _001_Eager()
        {
            using (var db = new TrainintDBContext())
            {
                var users = db.Users.Include(p => p.Documents).ToList();
            }
        }
    }
}
