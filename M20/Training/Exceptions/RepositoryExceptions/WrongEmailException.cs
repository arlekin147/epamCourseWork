using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    public class WrongEmailException : Exception
    {
        public WrongEmailException() : base() { }
        public WrongEmailException(string what) : base(what) { }
        public WrongEmailException(string what, Exception old) : base(what, old) { }
    }
}
