using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ADO_Net._005_DataSetStrictlyType
{
    public class _001_
    {
        public _001_()
        {
            var db = new DataSet1();

            DataSet1.PersonRow newPerson = db.Person.NewPersonRow();

            newPerson.Name = "Mico";
            newPerson.Phone = "92457448375";

            db.Person.Rows.Add(newPerson);

            db.Person.AddPersonRow("test", "test");

            foreach (DataRow row in db.Person.Rows)
            {
                foreach (DataColumn column in db.Person.Columns)
                    Console.WriteLine($"{column} : {row[column]}");
            }


            db.Person.AcceptChanges();
        }
    }
}
