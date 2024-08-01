using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public static class Email
    {
        public static bool verificarEmail(string email)
        {
           
            if (email.Contains(".") && email.Contains("@"))
            {
                return true;
            }

            else
            {
                return false;
            }
           
        }
    }
}
