using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirst.Examples._011_ComplexType
{
    /// <summary>
    /// Data saved in one tables
    /// </summary>
    class _001_ComplexType
    {
        [ComplexType]
        public class PhoneInfo
        {
            public string Company { get; set; }
            public int Price { get; set; }
        }

        public class Phone
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public PhoneInfo Info { get; set; }

            public Phone()
            {
                Info = new PhoneInfo { Price = 300 };
            }
        }
    }
}
