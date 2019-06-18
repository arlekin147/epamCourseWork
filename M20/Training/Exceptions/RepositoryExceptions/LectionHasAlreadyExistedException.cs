using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class LectionHasAlreadyExistedException : RepositoryException
    {
        public LectionHasAlreadyExistedException() : base() { }
        public LectionHasAlreadyExistedException(string what) : base(what) { }
        public LectionHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
