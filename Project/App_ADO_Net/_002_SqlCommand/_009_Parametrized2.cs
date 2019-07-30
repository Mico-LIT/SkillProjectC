using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ADO_Net._002_SqlCommand
{
    public class _009_Parametrized2
    {
        public void WriteReaderData(SqlDataReader reader)
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

        public _009_Parametrized2()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(sqlStr);
            connection.Open();

            //SqlCommand cmd = new SqlCommand("Execute getPerson 1", connection);

            SqlCommand cmd = new SqlCommand("getPerson", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Id", 1);

            SqlDataReader reader = cmd.ExecuteReader();

            WriteReaderData(reader);

            Console.Read();
        }
    }
}
