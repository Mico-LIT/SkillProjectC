using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace App_ADO_Net._003_DataSet
{
    public class _001_DataSet
    {
        public _001_DataSet()
        {
            DataSet ds = new DataSet();

            DataTable parentTable = new DataTable();
            DataTable childTable = new DataTable();

            DataColumn childColumn = childTable.Columns.Add("ChildColumn", typeof(int));
            DataColumn parentColumn = parentTable.Columns.Add("ParentColumn", typeof(int));

            ds.Tables.AddRange(new DataTable[] { childTable, parentTable });

            parentTable.Constraints.Add(new UniqueConstraint(parentColumn));
            childTable.Constraints.Add(new ForeignKeyConstraint(parentColumn, childColumn));

            DataRow parentRow = parentTable.NewRow();
            parentRow[0] = 1;
            parentTable.Rows.Add(parentRow);

            DataRow childRow = childTable.NewRow();
            childRow[0] = 1;

            //ошибка будет
            //childRow[0] = 1;
            //childTable.Rows.Add(childRow);

        }
    }
}
