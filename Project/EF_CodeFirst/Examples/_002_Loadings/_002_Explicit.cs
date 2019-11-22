using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst.Examples._002_Loadings
{
    /// <summary>
    /// Явная загрузка
    /// </summary>
    public class _002_Explicit
    {
        public _002_Explicit()
        {
            using (var db = new TrainintDBContext())
            {
                var doc = db.PersonalDocuments.FirstOrDefault();
                db.Entry(doc).Reference("User").Load();

                if (doc.User != null)
                {
                    Console.WriteLine(doc.Id);
                }

            }
        }
    }
}
