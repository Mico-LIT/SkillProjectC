using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_ADO_Net._001_SqlConnection
{
    public class _002_Pooling
    {
        public _002_Pooling()
        {
            // тыркай
            bool flag = true;

            string sqlStr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\Database1.mdf;Integrated Security=True;Pooling={flag.ToString()};";

            DateTime pointStart = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                var sqlConn = new SqlConnection(sqlStr);
                // При вкюченном пуле физическое подключение не создается, а берется из пула соединений
                sqlConn.Open();
                // При вкюченном пуле физическое подключение не разрывается, а помещается в пул
                sqlConn.Close();
            }

            var diff =  DateTime.Now- pointStart;

            Console.WriteLine(diff.TotalSeconds);
            Console.ReadLine();
        }
    }
}
