using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.Examples
{
    public class task
    {
        List<PersonFix> Pf = new List<PersonFix>();
        List<PersonTime> Pt = new List<PersonTime>();
        string[] name = new[] { "Дарья", "Анастасия", "Марина", "Елизавета", "Екатерина", "Ксения", "Виктория", "Валерия", "Полина", "Софья", "Ульяна" };
        Random Ran = new Random();

        public task()
        {

            NewPerson();
            #region а) упорядочить всю последовательность....
            foreach (var item in Pf)
            {
                System.Console.WriteLine(string.Format("{0} \t {1} \t {2}", item.Id, item.Name, item.Salary));
            }
             Pf.Sort(SortPf);
            System.Console.WriteLine("");
            foreach (var item in Pf)
            {
                System.Console.WriteLine(string.Format("{0} \t {1} \t {2}",item.Id,item.Name,item.Salary));
            }
            System.Console.ReadLine();
            #endregion
            
            // b)
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Pf[i].Name);
            }
            
            // c)
            for (int i = Pf.Count-1; i > Pf.Count-4; i--)
            {
                Console.WriteLine(Pf[i].Name);
            }
            Console.ReadLine();

            // d)
            XmlSerializer xml = new XmlSerializer(typeof(List<PersonFix>));
            using (FileStream fs=new FileStream("file.xml",FileMode.Create))
            {
                xml.Serialize(fs,Pf);
            }

            Console.WriteLine("Save file");
            // d)
            // e)
            XmlSerializer xml2 = new XmlSerializer(typeof(List<PersonFix>));
            List<PersonFix> pf2;
            using (FileStream fs = new FileStream("file.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    pf2 = (List<PersonFix>)xml.Deserialize(fs);

                }
                catch (Exception)
                {
                    throw new Exception("ERROR");
                }
            }
            Console.WriteLine("Download file\n");
            foreach (var item in pf2)
            {
                System.Console.WriteLine(string.Format("{0} \t {1} \t {2}", item.Id, item.Name, item.Salary));
            }
            Console.ReadLine();
        }

        private int SortPf(PersonFix x, PersonFix y)
        {
            if (x.Salary > y.Salary)
            {
                return 1;
            }
            else
            {
                if (x.Salary == y.Salary)
                {
                    if (x.Name[0] > y.Name[0])
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }
            }
            
            
        }

        private void NewPerson()
        {
            for (int i = 0; i < 20; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        var tmp = new PersonFix(i, name[Ran.Next(0, 10)], Ran.Next(10000, 50000));
                        Pf.Add(tmp);

                        /// Проврека
                        if (i == 2 || i== 6)
                        {
                            Pf.Add(new PersonFix(i, name[1], tmp.Salary));
                        }
                        break;

                    default:
                        
                        Pt.Add(new PersonTime(i, name[Ran.Next(0, 10)], Ran.Next(1, 100)));
                        break;
                }
            }

        }
    }
}
