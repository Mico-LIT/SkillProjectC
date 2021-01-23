using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._002_SqlCommand
{
    public class _003_ExecuteNonQuery
    {
        public _003_ExecuteNonQuery()
        {
            string sqlStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";


            var sqlConn = new SqlConnection(sqlStr);
            sqlConn.Open();
            try
            {
                SqlCommand insert = sqlConn.CreateCommand();
                insert.CommandText = "insert Person values(2,'1','1');";

                Console.WriteLine($"Processing rows INSERT: {insert.ExecuteNonQuery()}");

                SqlCommand delete = sqlConn.CreateCommand();
                delete.CommandText = "DELETE Person where id=2";

                Console.WriteLine($"Processing rows DELETE: {delete.ExecuteNonQuery()}");



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            Console.ReadLine();
        }
    }
}
