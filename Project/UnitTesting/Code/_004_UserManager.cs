using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code
{
    public class _004_UserManager
    {
        public bool Add(string userId, string phone, string email)
        {
            if (userId.Length < 5)
                throw new Exception("userId.Length need more 5 chars");

            if (!Regex.IsMatch(phone, @"\d"))
                throw new Exception("need only digital");

            if (!email.Contains("@"))
                throw new Exception("email need char @");

            return true;
        }

    }
}
