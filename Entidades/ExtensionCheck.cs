using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionCheck
    {
        public static bool EsMail(this string mail)
        {
            bool tieneCadenaDeMail = false;
            if(mail.EndsWith("@gmail.com") || mail.EndsWith("@hotmail.com") || mail.EndsWith("@yahoo.com"))
            {
                tieneCadenaDeMail = true;
            }
            return tieneCadenaDeMail;
        }

        public static bool EsSoloTexto(this string soloTexto)
        {
            if (string.IsNullOrWhiteSpace(soloTexto))
            {
                return false;
            }

            foreach (char c in soloTexto)
            {
                if (!char.IsLetter(c))
                {
                    return false; 
                }
                else if (char.IsWhiteSpace(c))
                {
                    continue; 
                }
            }

            return true; 
        }
    }
}
