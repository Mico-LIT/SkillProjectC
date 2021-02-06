using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ADO_Net._002_SqlCommand
{
    public class _006_DBNullValue
    {
        public _006_DBNullValue()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(sqlStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT NULL as Name,'12' as Age,55 AS Summ", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if(reader[0] != DBNull.Value)
                //if (!reader.IsDBNull(0))
                {
                    Console.WriteLine(reader.GetName(0) +": "+reader.GetValue(0));
                }
                else
                {
                    Console.WriteLine("Нет заначения");
                }
                Console.WriteLine(reader.GetName(1) + ": " + reader.GetValue(1));
                Console.WriteLine(reader.GetName(2) + ": " + reader.GetValue(2));

            }

            Console.ReadLine();
        }
    }
}
