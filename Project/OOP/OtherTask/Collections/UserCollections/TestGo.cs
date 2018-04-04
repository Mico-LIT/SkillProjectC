using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections.UserCollections
{
    class TestGo
    {
        public TestGo()
        {
            UserCollection userc = new UserCollection();
            
            foreach (Element item in userc)
            {
                Console.WriteLine(item.MyProperty1);
            }

            Console.ReadLine();

            // foreach приводит коллекцию к интерфейсному типу IEnumerable
            IEnumerable enumerable = userc as IEnumerable;

            // foreach приводит коллекцию к интерфейсному типу IEnumerator и вызывает метод
            IEnumerator enumerator = enumerable.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Element element = enumerator.Current as Element;

                Console.WriteLine($"{element.MyProperty1}");
            }

            enumerator.Reset();

            Console.ReadLine();

            foreach (var item in UserCollection2.Power())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
