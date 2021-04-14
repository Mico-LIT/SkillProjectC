using EF_Core_App.Entities;
using System;

namespace EF_Core_App
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User() { Age = 23, Name = "Misha" };
            Operations.Create(user);
            var userFind = Operations.Read(1);

            Console.WriteLine($"Hello World! Name {userFind.Name} | Id {userFind.Id} | Age{userFind.Age}");
            Console.Read();
        }
    }
}
