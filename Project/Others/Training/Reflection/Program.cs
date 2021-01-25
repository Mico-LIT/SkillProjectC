using System;
using System.Collections.Generic;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var empList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.Write(empList.GetType().Name);

            var genericArgument = empList.GetType().GetGenericArguments();
            foreach (var item in genericArgument)
                Console.WriteLine("[{0}]", item);

            Console.WriteLine(empList.GetType().FullName);

            var emp = new Employee();
            var empType = emp.GetType();
            var methodInfo = empType.GetMethod("SpeakV2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodInfo.Invoke(emp, null);

            methodInfo = empType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(emp, null);

            Console.Read();
        }

        private static object CreateCollection(Type collectionType, Type type)
        {
            var clocedType = collectionType.MakeGenericType(type);
            return Activator.CreateInstance(clocedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        private void SpeakV2()
        {
            Console.WriteLine("Hi");
        }

        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
}
