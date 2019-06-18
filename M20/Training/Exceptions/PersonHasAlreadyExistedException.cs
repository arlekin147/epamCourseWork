using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    public class PersonHasAlreadyExistedException : Exception
    {
        public PersonHasAlreadyExistedException() : base() { }
        public PersonHasAlreadyExistedException(string what) : base(what) { }
        public PersonHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
