using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.Models
{
    public static class AuthModel
    {
        public const string ValidUsername = "admin";
        public const string ValidPassword = "12345";

        public static bool Authenticate(string username, string password)
        {
            return string.Equals(username, ValidUsername, StringComparison.Ordinal) &&
                   string.Equals(password, ValidPassword, StringComparison.Ordinal);
        }
    }
}

