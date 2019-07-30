using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._002_SqlCommand
{
    public class _004_SqlDataReader
    {
        public _004_SqlDataReader()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(sqlStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from Person", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.WriteLine(reader.GetName(i) + ": " + reader[i]);
            //        // Console.WriteLine(reader.GetName(i) + ": " + reader.GetValue(i));
            //    }

            //    Console.WriteLine(new string('_', 20));
            //}

            while (reader.Read())
            {
                Console.WriteLine(reader.GetFieldValue<int>(0));
                Console.WriteLine(reader.GetFieldValue<string>(1));
                Console.WriteLine(reader.GetFieldValue<string>(2));

                Console.WriteLine(new string('_', 20));
            }

            reader.Close();
            connection.Close();

            Console.ReadLine();
        }
    }
}
