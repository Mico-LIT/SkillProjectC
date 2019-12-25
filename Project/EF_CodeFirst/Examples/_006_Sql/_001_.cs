using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst.Examples._006_Sql
{
    public class _001_
    {
        public _001_()
        {
            using (var db = new TrainintDBContext())
            {
                Console.WriteLine(db.Database.Connection.ConnectionString);

                var item = db.Database.SqlQuery<Phone>("select * from Phones").ToList();

                var param = new SqlParameter("@Id", 1);

                item = db.Database.SqlQuery<Phone>("select * from Phones where Id = @Id", param).ToList();

                param = new SqlParameter("@Id", "1");
                item = db.Database.SqlQuery<Phone>("select * from GetPhones (@Id)", param).ToList();

                param = new SqlParameter("@Number", "1");
                var users = db.Database.SqlQuery<User>("GetUserByPhoneNumber @Number", param).ToList();


                // вставка
                //int numberOfRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO Companies (Name) VALUES ('HTC')");
                // обновление
                //int numberOfRowUpdated = db.Database.ExecuteSqlCommand("UPDATE Companies SET Name='Nokia' WHERE Id=3");
                // удаление
                //int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM Companies WHERE Id=3");
            }
        }
    }
}
