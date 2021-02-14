using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code
{
    public class _002_PasswordCheck
    {
        public int GetPasswordStrength(string password)
        {

            if (string.IsNullOrWhiteSpace(password))
                return 0;

            int conutStrength = 0;

            if (Math.Max(password.Length, 7) > 7)
                conutStrength++;

            if (Regex.Match(password, "[a-z]").Success)
                conutStrength++;
            if (Regex.Match(password, "[A-Z]").Success)
                conutStrength++;
            if (Regex.Match(password, "[0-9]").Success)
                conutStrength++;
            if (Regex.Match(password, @"[\\!\\@\\#\\$]").Success)
                conutStrength++;

            return conutStrength;
        }
    }
}
