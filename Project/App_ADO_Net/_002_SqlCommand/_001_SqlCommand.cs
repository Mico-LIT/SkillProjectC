using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._002_SqlCommand
{
    public class _001_SqlCommand
    {
        public _001_SqlCommand()
        {
            string sqlStr = 
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            SqlConnection sqlConn = new SqlConnection(sqlStr);

            //1
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandText = "SELECT 1";
            //2

            cmd = sqlConn.CreateCommand();
            cmd.CommandText = "SELECT 1";
            //3

            cmd = new SqlCommand("SELECT 1", sqlConn);
        }
    }
}
