using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _006_Models.Models._002_FatModel
{
    public class Company
    {
        public ulong Id { get; set; }
        public string Name { get; set; }

        public Company(ulong id, string name)
        {
            Id = id;
            Name = name;
        }

        public string GetInfo()
        {
            return $"FatModel.  Id {Id} Name {Name}";
        }


    }
}
