using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._001_SelectInfo
{
    public class _001_Info
    {
        public _001_Info()
        {
            using (var db = new TrainintDBContext())
            {
                var airplanes = db.Airplanes.ToList();
                foreach (var item in airplanes)
                {
                    Console.WriteLine($"{item.Name}  {item.Year} {item.CountWheel} ");
                }
            }
        }
    }
}
