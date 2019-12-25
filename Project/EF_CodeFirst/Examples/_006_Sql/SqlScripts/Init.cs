using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._006_Sql.SqlScripts
{
    static class Init
    {
        static public string[] GetSqlTexts()
        {
            List<string> list = new List<string>();

            string[] strings = new string[]
            {
                "EF_CodeFirst.Examples._006_Sql.SqlScripts.FuncGetPhones.sql",
                "EF_CodeFirst.Examples._006_Sql.SqlScripts.ProcGetUserByPhoneNumber.sql"
            };

            foreach (var item in strings)
                list.Add(Get(item));

            return list.ToArray();
        }

        static string Get(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlText = string.Empty;
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader sr = new StreamReader(stream))
                {
                    sqlText = sr.ReadToEnd();
                }

                return sqlText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
