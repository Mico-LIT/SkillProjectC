using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Reflection._Type
{
    class TypeTest3
    {
        sealed class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public event EventHandler Modified;

            void OnModified()
            {
                EventHandler handler = Modified;
                if (handler != null) handler.Invoke(this,EventArgs.Empty);
            }

            public void Save() { }
        }
        
        public TypeTest3()
        {
            Type t = typeof(Person);

            TypeInfo info = t.GetTypeInfo();

            IEnumerable<PropertyInfo> prop = info.DeclaredProperties;
            Print(prop);

            IEnumerable<MethodInfo> method = info.DeclaredMethods;
            Print(method);

            IEnumerable<EventInfo> even = info.DeclaredEvents;
            Print(even);

            Console.ReadLine();
        }

        private void Print(IEnumerable<MemberInfo> members )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{members.GetType().GetElementType().Name}");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (var item in members)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('_' ,20));

        }
    }
}
