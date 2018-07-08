using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CSharp.Professional.RegistryBasics
{
    class Registr
    {
        public Registr()
        {
            if (false)
            {
            // Создаем
            RegistryKey key = Registry.CurrentUser;
            RegistryKey wkey = key.OpenSubKey("Software",true);
            try
            {
                wkey.CreateSubKey("d12");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                wkey.Close();
            };

            // Записываем
            RegistryKey subkey = key.OpenSubKey("Software",true);
            RegistryKey subsubkey = subkey.OpenSubKey("D12",true);
            subsubkey.SetValue("t1", 123);
            subsubkey.SetValue("str", "1234");
            subsubkey.SetValue("t2", 333,RegistryValueKind.String);
            subkey.Close();
            subsubkey.Close();
            }
            // Читаем

            RegistryKey key2 = Registry.CurrentUser;
            RegistryKey subkey2 = key2.OpenSubKey(@"Software\d12");

            string str = subkey2.GetValue("str") as string;
            int i = Convert.ToInt32(subkey2.GetValue("t1"));
            int i2 = Convert.ToInt32(subkey2.GetValue("t2"));
            Console.WriteLine($"{str} {i} {i2}");

            Console.ReadLine();
        }
    }
}
