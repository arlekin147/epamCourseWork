using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    class SubstringNotFoundException : Exception
    {
        public SubstringNotFoundException() : base() { }
        public SubstringNotFoundException(string what) : base(what) { }
        public SubstringNotFoundException(string what, Exception old) : base(what, old) { }
    }
}
