using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Collections
{
    public class Collections6
    {
        public Collections6()
        {
            int[] nums = { 1, 2, 3, 4, 3, 55, 23, 2 };
            int[] dist = nums.Distinct().ToArray();

            string[] animals = { "Cat", "Alligator", "Fox", "Donkey", "Cat" };
            string[] dist2 = animals.Distinct().ToArray();


            Person[] people = {
                new Person(){ FirstName="Steve", LastName="Jobs"},
                new Person(){ FirstName="Bill", LastName="Gates"},
                new Person(){ FirstName="Steve", LastName="Jobs"},
                new Person(){ FirstName="Lary", LastName="Page"}
            };

            var peopleDist = people.Distinct(new PersonComparer()).ToArray();

            Array.Sort(people,new PersonComparerObject());

        }

        class PersonComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.FirstName == y.FirstName && x.LastName == x.LastName;
            }

            public int GetHashCode(Person obj)
            {
                var g = ((obj.FirstName == null) ? 0 : obj.FirstName.GetHashCode());
                return obj.Id.GetHashCode() ^ g ^ ((obj.LastName == null) ? 0 : obj.LastName.GetHashCode());
            }
        }

        class PersonComparerObject : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(((Person)x).LastName, ((Person)y).LastName);
            }
        }

        class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }
    }
}
