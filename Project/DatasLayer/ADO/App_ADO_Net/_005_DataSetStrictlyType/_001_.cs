using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_ADO_Net._005_DataSetStrictlyType.DataSet1TableAdapters;

namespace App_ADO_Net._005_DataSetStrictlyType
{
    public class _001_
    {
        // Как локальная точка + схема
        private static DataSet1 db = new DataSet1();

        ~_001_()
        {
            db.Dispose();
        }

        public _001_()
        {
            ChangesLocalDb();
            GetPersonInDb();
            InsertPersonInDb();
        }

        private void InsertPersonInDb()
        {
            var personTable = new PersonTableAdapter();

            personTable.Insert("coll777", "89521445786");
            personTable.Fill(db.Person);

            foreach (DataRow row in db.Person.Rows)
            {
                foreach (DataColumn column in db.Person.Columns)
                    Console.WriteLine($"{column} : {row[column]}");
            }

            Clear();
            GetPersonInDb();
        }

        void GetPersonInDb()
        {
            var personTable = new PersonTableAdapter();
            personTable.Fill(db.Person);

            foreach (DataRow row in db.Person)
            {
                foreach (DataColumn column in db.Person.Columns)
                    Console.WriteLine($"{column} : {row[column]}");
            }

            Clear();
        }

        void ChangesLocalDb()
        {
            // Строго типизированный объект. например для передачи на низкий уровень в многоуровневой архитектуре
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

            Clear();
        }

        void Clear()
        {
            Console.WriteLine(new string('_', 20));
            db.Clear();
        }
    }
}
