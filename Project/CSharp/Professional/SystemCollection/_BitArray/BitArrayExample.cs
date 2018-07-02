using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._BitArray
{
    class BitArrayExample
    {
        public BitArrayExample()
        {
            BitArray bits = new BitArray(3);
            bits[0] = false;
            bits[1] = true;
            bits[2] = false;
            Console.WriteLine(bits.Length);

            // Для именения размера необходимо воспользоваться свойством Length.
            bits.Length = 4;
            bits[3] = true;
            Console.WriteLine(bits.Length);

            Console.ReadLine();
        }
    }
}
