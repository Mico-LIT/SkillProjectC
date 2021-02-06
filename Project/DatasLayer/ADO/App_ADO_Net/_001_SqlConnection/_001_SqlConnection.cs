using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._001_SqlConnection
{
    public class _001_SqlConnection
    {
        public _001_SqlConnection()
        {
            string conStr =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            using (var sqlConn = new SqlConnection(conStr))
            {
                sqlConn.StateChange += SqlConn_StateChange;

                try
                {
                    sqlConn.Open();
                    //throw new Exception();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            Console.ReadLine();
        }

        private void SqlConn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            var sqlConnInstance = sender as SqlConnection;

            if (sqlConnInstance != null)
            {
                Console.WriteLine(sqlConnInstance.State);
                Console.WriteLine(sqlConnInstance.DataSource);
                Console.WriteLine(sqlConnInstance.Database);
            }
        }
    }
}
