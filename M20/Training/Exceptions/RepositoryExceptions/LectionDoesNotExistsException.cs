using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class LectionDoesNotExistsException : RepositoryException
    {
        public LectionDoesNotExistsException() : base() { }
        public LectionDoesNotExistsException(string what) : base(what) { }
        public LectionDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
