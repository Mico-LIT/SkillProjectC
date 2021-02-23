using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// InternalsVisibleTo - указывает, что типы, которые обычно доступны только в текущей сборке будут доступны также в сборке,
// которая определена в параметрах.
[assembly: InternalsVisibleTo("Code.Tests")]

namespace Code.InternalClassTest
{
    // по умолчанию типа доступа Internal (Доступна в текущей сборки)
    class _001_Example
    {
        public bool Tmp()
        {
            return true;
        }
    }
}
