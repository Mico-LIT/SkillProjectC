using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ADO_Net._002_SqlCommand
{
    public class _007_Transactions
    {
        public _007_Transactions()
        {

            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            var sqlConn = new SqlConnection(sqlStr);
            sqlConn.Open();

            SqlCommand insert = sqlConn.CreateCommand();
            insert.Transaction = sqlConn.BeginTransaction();

            try
            {

                insert.CommandText = "insert Person values(3,'3','3');";

                Console.WriteLine($"Processing rows INSERT: {insert.ExecuteNonQuery()}");

                //throw new Exception("Error"); // For Test!

                insert.Transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                insert.Transaction.Rollback();
            }
            finally
            {
                sqlConn.Close();
            }

            Console.ReadLine();

        }
    }
}
