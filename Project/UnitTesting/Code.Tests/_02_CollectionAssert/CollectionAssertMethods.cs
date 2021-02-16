using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._02_CollectionAssert
{
    [TestClass]
    public class CollectionAssertMethods
    {
        static List<string> employees;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            employees = new List<string>();
            employees.Add("Invan");
            employees.Add("Anton");
            employees.Add("Sergey");
            employees.Add("Misha");
        }


        [TestMethod]
        public void AllItemsAreNotNullTest()
        {
            CollectionAssert.AllItemsAreNotNull(employees, "Failed");
        }

        [TestMethod]
        public void AllItemsAreUniqueTest()
        {
            CollectionAssert.AllItemsAreUnique(employees, "not unique");
        }

        [TestMethod]
        public void AreEqualTest()
        {
            var _employees = new List<string>();
            _employees.Add("Invan");
            _employees.Add("Anton");

            // Поменять порядок и будет ошибка
            _employees.Add("Sergey");
            _employees.Add("Misha");
            //_employees.Add("Misha");

            CollectionAssert.AreEqual(employees, _employees);
        }

        [TestMethod]
        public void SubSetTest()
        {
            var employeesSubSet = new List<string>();
            //_employees.Add("Invan2");
            employeesSubSet.Add("Invan");

            // Проверка employeesSubSet вхотят в коллекцию employees
            CollectionAssert.IsSubsetOf(employeesSubSet, employees, "not Subset");
        }



    }
}
