using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._BitArray
{
    class BitArrayExample2
    {
        public BitArrayExample2()
        {
            BitArray bits = new BitArray(3);
            bits[0] = false;
            bits[1] = true;
            bits[2] = false;
            Console.WriteLine(bits.Length);

            BitArray bits2 = new BitArray(3);
            bits2[0] = false;
            bits2[1] = true;
            bits2[2] = false;
              
            BitArray xorBits = bits.Xor(bits2);

            foreach (bool item in xorBits)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
