using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    public class PersonDoesNotExistsException : Exception
    {
        public PersonDoesNotExistsException() : base() { }
        public PersonDoesNotExistsException(string what) : base(what) { }
        public PersonDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
