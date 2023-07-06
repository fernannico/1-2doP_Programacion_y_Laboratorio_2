using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionesPropias : Exception
    {
        public List<Exception> InnerExceptions { get; }

        public ExcepcionesPropias(string message) : base(message) 
        {

        }

        public ExcepcionesPropias(string message, List<Exception> innerExceptions) : base(message)
        {
            InnerExceptions = innerExceptions;
        }
    }
}
