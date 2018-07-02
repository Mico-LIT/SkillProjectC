using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace CSharp.Professional.SystemCollection._BitVector32
{
    class BitVector32Example
    {
        public BitVector32Example()
        {
            var vector = new BitVector32(0);

            int firstBit = BitVector32.CreateMask();         // ... 0000 0001
            int secondBit = BitVector32.CreateMask(firstBit);// ... 0000 0010
            int thirdBit = BitVector32.CreateMask(secondBit);// ... 0000 0100

            Console.WriteLine($"{firstBit} {secondBit} {thirdBit}");

            Console.WriteLine(vector.Data);

            var newVector = new BitVector32(4);
            Console.WriteLine(newVector);

            bool bit1 = newVector[firstBit];
            bool bit2 = newVector[secondBit];
            bool bit3 = newVector[thirdBit];

            Console.WriteLine($"{bit1} {bit2} {bit3}");

            Console.ReadLine();
        }
    }
}
