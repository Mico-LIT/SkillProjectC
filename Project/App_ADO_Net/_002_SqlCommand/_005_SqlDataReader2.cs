using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace App_ADO_Net._002_SqlCommand
{
    public class _005_SqlDataReader2
    {
        public void WriteReaderData(DbDataReader reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + ": " + reader.GetValue(i));
                }
                Console.WriteLine(new string('_', 20));
            }
        }

        public _005_SqlDataReader2()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(sqlStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from Person; SELECT 2 as tmp", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            WriteReaderData(reader);

            if (reader.NextResult())
            {
                WriteReaderData(reader);
            }

            reader.Close();
            connection.Close();

            Console.Read();
        }
    }
}
