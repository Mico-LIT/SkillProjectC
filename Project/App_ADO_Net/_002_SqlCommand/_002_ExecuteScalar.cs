using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._002_SqlCommand
{
    public class _002_ExecuteScalar
    {
        public _002_ExecuteScalar()
        {
            string sqlStr =
    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection sqlConn = new SqlConnection(sqlStr);
            sqlConn.Open();

            SqlCommand cmd = new SqlCommand("Select 1", sqlConn);

            var number = (int)cmd.ExecuteScalar();

            Console.WriteLine(number);
            Console.ReadLine();
        }
    }
}
