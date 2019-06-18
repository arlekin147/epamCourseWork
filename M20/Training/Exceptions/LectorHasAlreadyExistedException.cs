using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    class LectorHasAlreadyExistedException : PersonHasAlreadyExistedException
    {
        public LectorHasAlreadyExistedException() : base() { }
        public LectorHasAlreadyExistedException(string what) : base(what) { }
        public LectorHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
