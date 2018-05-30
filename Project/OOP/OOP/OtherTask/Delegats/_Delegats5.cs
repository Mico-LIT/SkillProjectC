using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats5
{
    public delegate int Mydelegats(int x);
    public delegate void Mydelegats2();
    class _Delegats5
    {
        public _Delegats5()
        {
            Mydelegats mydelegate;
            Mydelegats2 mydelegats2;

            mydelegate = delegate (int x) { return x * 2; }; // Лямда метод

            mydelegate = (x) => { return x * 2; }; //Лямда оператор 

            mydelegate = x => x * 2; //Лямда выражение

            mydelegats2 = () => { Console.WriteLine("HI"); };

            int i = mydelegate(2);

            Console.WriteLine(i);
        }
    }
}
