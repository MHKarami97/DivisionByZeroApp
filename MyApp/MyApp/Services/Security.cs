using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Services
{
    public class Security
    {
        public static bool EmailValid(string email)
        {
            try
            {
                var result = new System.Net.Mail.MailAddress(email);

                return result.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool PasswordValid(string password)
        {
            return password.Length > 8 && password.Any(char.IsLower) && password.Any(char.IsDigit);
        }
    }
}
