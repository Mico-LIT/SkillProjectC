using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EF_CodeFirst.Examples._004_Transaction
{
    public class _001_Transaction
    {
        public _001_Transaction()
        {
            using (var db = new TrainintDBContext())
            {
                db.Database.Log = Console.Write;

                using (var bt = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("UPDATE Users set Age = 1 where Id = 1");
                        db.Users.Add(new Models.User.User()
                        {
                            Name = "TEST"
                        });

                        db.SaveChanges();
                        bt.Commit();

                    }
                    catch (Exception ex)
                    {
                        bt.Rollback();
                    }
                }
            }
        }
    }
}