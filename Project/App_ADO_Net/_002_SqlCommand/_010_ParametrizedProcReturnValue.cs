using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ADO_Net._002_SqlCommand
{
    public class _010_ParametrizedProcReturnValue
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

        public _010_ParametrizedProcReturnValue()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(sqlStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("ReturnValue", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            var param = cmd.Parameters.Add(new SqlParameter());
            param.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            Console.WriteLine(param.Value);

            Console.Read();
        }
    }
}
