using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class LectionDoesNotExistException : RepositoryException
    {
        public LectionDoesNotExistException() : base() { }
        public LectionDoesNotExistException(string what) : base(what) { }
        public LectionDoesNotExistException(string what, Exception old) : base(what, old) { }
    }
}
