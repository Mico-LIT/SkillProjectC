using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace App_ADO_Net._004_SqlDataAdapter
{
    public class _001_SqlDataAdapter
    {
        public _001_SqlDataAdapter()
        {
            string sqlConn =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;";

            string commandStr = "Select * from Person";

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandStr, sqlConn);

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.WriteLine("{0} {1}", col.ColumnName, row[col]);
                }
            }

            Console.Read();
        }
    }
}
